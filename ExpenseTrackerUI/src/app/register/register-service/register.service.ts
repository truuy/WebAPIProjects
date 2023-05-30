import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private loginUrl = 'https://localhost:7030/api/Users/createuser';

  constructor(private http: HttpClient) { }

  register(user: { username: string, password: string, email: string }) {
    return this.http.post(this.loginUrl, user).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 400 && error.error === 'Invalid email format') {
      window.alert('Invalid email format');
      console.error('Invalid email format');
    } else {
      console.error('An unknown error occurred:', error.error || 'Server error');
    }
    return throwError('Registration failed');
  }
}
