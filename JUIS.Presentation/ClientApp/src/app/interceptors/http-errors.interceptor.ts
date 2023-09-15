import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable()
export class HttpErrorsInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMsg = '';
          if (error.error instanceof ErrorEvent) {
            errorMsg = `Error: ${error.error.message}`;
          }
          //else {
          //  errorMsg = `Error Code: ${error.status}, Message: ${error.message}`;
          //  // Check for server unavailability
          //  if (error.status === 0) {
          //    errorMsg = 'The server is currently unavailable. Please try again later.';
          //  }
          //}
          //window.alert(errorMsg);
          return throwError(errorMsg);
        })
      )
  }
}
