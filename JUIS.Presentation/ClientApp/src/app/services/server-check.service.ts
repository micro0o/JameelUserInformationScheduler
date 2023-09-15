import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, timer, of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ServerCheckService {
  private readonly checkInterval = 5000; // Check every 5 seconds

  constructor(private http: HttpClient) { }

  isServerAvailable(): Observable<boolean> {
    return timer(0, this.checkInterval).pipe(
      switchMap(() => this.http.get('https://localhost:7232/healthCheck', { responseType: 'text' }).pipe(
        map(() => true), // Map the response to true
        catchError((error) => { console.log("the server is down1", error); return of(false) })
      )),
      catchError((error) => { console.log("the server is down2", error); return of(false) })
    );
  }
}
