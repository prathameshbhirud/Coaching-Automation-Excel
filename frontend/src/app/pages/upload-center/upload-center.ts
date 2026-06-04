import { Component, inject, ChangeDetectorRef } from '@angular/core';

import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { FileUploadService } from '../../core/services/file-upload.service';
import { PreviewService } from '../../core/services/preview.service';
import { NotificationService } from '../../core/services/notification.service';

@Component({
    selector: 'app-upload-center',
    imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule
    ],
    templateUrl: './upload-center.html',
    styleUrl: './upload-center.scss',
})
export class UploadCenter {
  private fileUploadService = inject(FileUploadService);
  private previewService = inject(PreviewService);
  private notificationService = inject(NotificationService);
  private cdr = inject(ChangeDetectorRef);

  attendanceFile?: File;
  attendancePreview: any;
  attendanceResult: any;

  onAttendanceSelected(event: Event) {
      const input = event.target as HTMLInputElement;

      if(input.files?.length) {
          this.attendanceFile =input.files[0];
      }
  }

  uploadAttendance() {
      if(!this.attendanceFile)
        return;

      this.fileUploadService.uploadAttendance(this.attendanceFile).subscribe(() => {
        this.loadAttendancePreview();
      });
  }

  loadAttendancePreview() {
    this.previewService.attendance().subscribe(result => {
      this.attendancePreview = result;
      this.cdr.detectChanges();
    });
  }

  sendAttendance() {
    this.notificationService.runAttendance().subscribe(result => {
      this.attendanceResult = result;
    });
  }
}
