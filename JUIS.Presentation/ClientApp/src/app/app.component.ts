import { Component } from '@angular/core';
import { UserService } from './services/user.service';
import { SignalRService } from './services/signalr.service';
import { UserStateService } from './services/user-state.service';
import { User } from './interfaces/user';
import { FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { ServerCheckService } from './services/server-check.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Jameel Scheduler';
  user: User = {};
  users$ = this.userState.users$;

  showFillRequiredFieldsAlert = false;

  userForm = this.formBuilder.group({
    firstName: new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    dateOfBirth: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required])
  });

  isServerAvailable$: Observable<boolean> = this.serverCheck.isServerAvailable();

  constructor(
    private userService: UserService,
    private signalRService: SignalRService,
    private userState: UserStateService,
    private formBuilder: FormBuilder,
    private serverCheck: ServerCheckService
  ) { }

  ngOnInit() {
    //this.isServerAvailable$ = this.serverCheck.isServerAvailable();

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

  onSubmit(): void {
    if (this.userForm.valid) {
      this.showFillRequiredFieldsAlert = false;
      // send the request
      // Process checkout data here
      this.user = {};
      this.user.firstName = this.userForm.get('firstName')?.value ?? "";
      this.user.lastName = this.userForm.get('lastName')?.value ?? "";
      this.user.dateOfBirth = this.userForm.get('dateOfBirth')?.value ?? "";
      this.user.address = this.userForm.get('address')?.value ?? "";
      this.user.phoneNumber = this.userForm.get('phoneNumber')?.value ?? "";

      this.addUser();
    } else {
      // handle the invalid form...
      this.showFillRequiredFieldsAlert = true;
    }
    
  }

  addUser() {
    this.userService.addUser(this.user).subscribe(response => {
      console.log(response);
    });
  }
}
