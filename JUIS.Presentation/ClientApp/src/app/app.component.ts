import { Component } from '@angular/core';
import { UserService } from './services/user.service';
import { SignalRService } from './services/signalr.service';
import { UserStateService } from './services/user-state.service';
import { User } from './interfaces/user';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Jameel Scheduler';
  user: User = {};
  users$ = this.userState.users$;
  displayedColumns: string[] = ['firstName', 'lastName', 'dateOfBirth', 'phoneNumber', 'address'];

  firstName = new FormControl('', [Validators.required]);
  lastName = new FormControl('', [Validators.required]);
  dateOfBirth = new FormControl('', [Validators.required]);
  phoneNumber = new FormControl('', [Validators.required]);
  address = new FormControl('', [Validators.required]);

  constructor(
    private userService: UserService,
    private signalRService: SignalRService,
    private userState: UserStateService
  ) { }

  ngOnInit() {
    this.userService.getUsers().subscribe(users => {
      this.userState.setUsers(users);
    });

    this.signalRService.startConnection();
    this.signalRService.hubConnection?.on('UserAdded', (user: User) => {
      console.log('UserAdded ==> ', user);
      this.userService.getUsers().subscribe((users: User[]) => {
        this.userState.setUsers(users);
      });
    });
  }

  addUser() {
    this.userService.addUser(this.user).subscribe(response => {
      console.log(response);
    });
  }
}
