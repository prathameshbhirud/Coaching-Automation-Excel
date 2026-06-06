import { Component } from '@angular/core';

import { RouterModule } from '@angular/router';

import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-sidebar',

  standalone: true,

  imports: [
    RouterModule,
    MatListModule,
    MatIconModule,
    MatButtonModule
  ],

  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.scss']
})
export class Sidebar {
  constructor(private auth: AuthService) {}

  logout() {
    this.auth.logout();
  }
}