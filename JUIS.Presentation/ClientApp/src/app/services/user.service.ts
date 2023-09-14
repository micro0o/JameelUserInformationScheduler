import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7232/api/User';

  constructor(private http: HttpClient) { }

  addUser(user: any): Observable<any> {
    return this.http.post<User>(`${this.apiUrl}/addUser`, user);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/getUsers`);
  }
}
