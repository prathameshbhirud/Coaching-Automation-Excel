import {Component, Input, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';

import { FileUploadService } from '../../../core/services/file-upload.service';
import { PreviewService } from '../../../core/services/preview.service';
import { NotificationService } from '../../../core/services/notification.service';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-upload-module',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule
  ],
  templateUrl: './upload-module.html',
  styleUrls: ['./upload-module.scss']
})
export class UploadModule {

  private fileUploadService = inject(FileUploadService);
  private previewService = inject(PreviewService);
  private notificationService = inject(NotificationService);
  private cdr = inject(ChangeDetectorRef);

  @Input() title = '';
  @Input() moduleType = '';

  selectedFile?: File;
  preview: any;
  result: any;

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;

    if(input.files?.length) {
      this.selectedFile = input.files[0];
    }
  }

  upload() {
    if(!this.selectedFile)
      return;

    switch(this.moduleType) {
      case 'attendance':
          this.fileUploadService.uploadAttendance(this.selectedFile).subscribe(() => {
            this.loadPreview();
            this.cdr.detectChanges();
          });
          break;

      case 'fees':
          this.fileUploadService.uploadFees(this.selectedFile).subscribe(() => {
            this.loadPreview();
            this.cdr.detectChanges();
          });
          break;

      case 'exams':
          this.fileUploadService.uploadExams(this.selectedFile).subscribe(() => {
            this.loadPreview();
            this.cdr.detectChanges();
          });
          break;

      case 'broadcast':
          this.fileUploadService.uploadBroadcast(this.selectedFile).subscribe(() => {
            this.loadPreview();
            this.cdr.detectChanges();
          });
          break;
      }
    }

  loadPreview() {
    switch(this.moduleType) {
      case 'attendance':
        this.previewService.attendance().subscribe(x => {
          this.preview = x;
          this.cdr.detectChanges();
        });
        break;

      case 'fees':
        this.previewService.fees().subscribe(x => {
          this.preview = x;
          this.cdr.detectChanges();
        });
        break;

      case 'exams':
        this.previewService.exams().subscribe(x => {
          this.preview = x;
          this.cdr.detectChanges();
        });
        break;

      case 'broadcast':
        this.previewService.broadcast().subscribe(x => {
          this.preview = x;
          this.cdr.detectChanges();
        });
        break;
      }
    }


    send() {
      switch(this.moduleType) {
        case 'attendance':
          this.notificationService.runAttendance().subscribe(x => {
            this.result = x;
            this.cdr.detectChanges();
          });
          break;

        case 'fees':
          this.notificationService.runFees().subscribe(x => {
            this.result = x;
            this.cdr.detectChanges();
          });
          break;

        case 'exams':
          this.notificationService.runExams().subscribe(x => {
            this.result = x;
            this.cdr.detectChanges();
          });
          break;

        case 'broadcast':
          this.notificationService.runBroadcast().subscribe(x => {
            this.result = x;
            this.cdr.detectChanges();
          });
          break;
        }
    }
}