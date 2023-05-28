import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl = 'https://localhost:7030/api/Users/login';

  constructor(private http: HttpClient) { }

  login(username: string, password: string)
  {
    const body = { username, password };
    return this.http.post(this.loginUrl, body);
  }
}
