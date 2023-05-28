import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterService } from './register-service/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  username!: string;
  password!: string;
  email!: string;

  constructor(
    private registerService: RegisterService,
    private router: Router
    ) { }

    register() {
      this.registerService.register(this.username, this.password, this.email).subscribe({
        next: response => {
          // Handle successful login response
          console.log('Registration successful.');
          window.alert('Registration successful.');
          //Redirect to dashboard after successful login
          this.router.navigate(['/login']);
        },
        error: error => {
          // Handle login error
          window.alert('Registration failed.');
          console.log('Registration failed.' + error  );
          this.username = '';
          this.password = '';
        }
      });
    }
  }
  