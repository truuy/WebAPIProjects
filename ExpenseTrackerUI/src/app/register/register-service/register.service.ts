import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private loginUrl = 'https://localhost:7030/api/Users/createuser';

  constructor(private http: HttpClient) { }

  register(username: string, password: string, email: string)
  {
    const body = { username, password, email};
    return this.http.post(this.loginUrl, body);
  }
}
