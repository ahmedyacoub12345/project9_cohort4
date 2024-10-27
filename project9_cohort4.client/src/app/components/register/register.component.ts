import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  username = '';
  email = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  onRegister() {
    this.authService.register({ username: this.username, email: this.email, password: this.password }).subscribe(
      response => {
        // Handle successful registration
        console.log(response);

        alert("Register Sucessfully!")
        this.router.navigate(['/login']); // Redirect to login after registration
      },
      error => {
        console.error('Registration failed', error);
        alert("Something went wrong! Try Again Please")
      }
    );
  }
}
