import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterService } from './register-service/register.service';
import { HttpHeaders } from '@angular/common/http';

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
      const user = { username: this.username, password: this.password, email: this.email };
    
      this.registerService.register(user).subscribe(
        response => {    
          // Handle successful registration
          console.log('Registration successful.');
          window.alert('Registration successful.');
          this.router.navigate(['/login']);
        },
        error => {
          // Log the error to the console
          console.log('Registration error:', error.errorMessage);
    
          // Handle registration error
          window.alert('Registration failed. Please check the console for more details.');
          this.username = '';
          this.password = '';
        }
      );
    }

    loginPage() {

      this.router.navigate(['/login']);
  
    }
    
    
  }
  