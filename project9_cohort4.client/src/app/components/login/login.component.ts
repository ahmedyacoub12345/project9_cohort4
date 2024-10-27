import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  email = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  onLogin() {
    this.authService.login({ email: this.email, password: this.password }).subscribe(
      response => {
        // Handle successful login
        console.log(response);
        alert("Login Sucessfully!")

        localStorage.setItem('token', response.token); // Store token
        this.router.navigate(['/']); // Redirect after login
      },
      error => {
        console.error('Login failed', error);
      }
    );
  }
}
