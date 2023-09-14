import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStateService {
  _users = new BehaviorSubject<any[]>([]);
  users$ = this._users.asObservable();

  constructor() { }


  setUsers(users: any[]) {
    this._users.next(users);
  }

  addUser(user: any) {
    const currentValue = this._users.value;
    this._users.next([...currentValue, user]);
  }

}
