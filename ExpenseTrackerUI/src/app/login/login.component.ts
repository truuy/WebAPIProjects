import { Component } from '@angular/core';
import { LoginService } from './login-service/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username!: string;
  password!: string;

  constructor(
    private loginService: LoginService,
    private router: Router
    
    
    ) { }

  login() {
    this.loginService.login(this.username, this.password).subscribe({
      next: response => {
        // Handle successful login response
        console.log('Login successful.');
        //Redirect to dashboard after successful login
        this.router.navigate(['/dashboard']);
      },
      error: error => {
        // Handle login error
        window.alert('Login Failed: Incorrect username or password.');
        console.log('Login Failed: Incorrect username or password.');
        this.username = '';
        this.password = '';
      }
    });
  }

  register() {

    this.router.navigate(['/register']);

  }
}
