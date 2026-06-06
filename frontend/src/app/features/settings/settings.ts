import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import { SettingsService } from '../../core/services/settings.service';
import { SettingsModel } from '../../core/models/settings.model';

@Component({
  selector: 'app-settings',
  standalone: true,

  imports: [
    CommonModule,
    FormsModule,
    MatTabsModule,
    MatInputModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatFormFieldModule
  ],

  templateUrl: './settings.html',
  styleUrls: ['./settings.scss']
})
export class Settings implements OnInit {

  model!: SettingsModel;

  constructor(private service: SettingsService, private snack: MatSnackBar, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.service.get().subscribe(x => {
      this.model = x;
      this.cdr.detectChanges();
    });
  }

  save() {
    this.service.save(this.model).subscribe(() => {
      this.snack.open(
        'Settings Saved',
        'Close',
        {
          duration: 3000
        });
        this.cdr.detectChanges();
    });
  }
}