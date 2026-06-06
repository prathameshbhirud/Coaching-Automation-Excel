import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { FormsModule } from '@angular/forms';

import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,

  imports: [
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule
  ],

  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class Login {

  username = '';
  password = '';

  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  login()
  {
    this.auth.login({
      username: this.username,
      password: this.password
    })
    .subscribe({
      next: response => {
        this.auth.saveToken(response.token);
        this.router.navigate(['/dashboard']);
      },

      error: () => {
        alert('Invalid username or password');
      }
    });
  }
}