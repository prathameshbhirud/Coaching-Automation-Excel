import { ChangeDetectorRef, Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { ReportsService } from '../../core/services/reports.service';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [
    CommonModule,
    MatTabsModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './reports.html',
  styleUrls: ['./reports.scss']
})
export class Reports implements OnInit {

  private reportsService = inject(ReportsService);
  private cdr = inject(ChangeDetectorRef);

  attendanceData: any[] = [];
  feesData: any[] = [];
  examData: any[] = [];
  broadcastData: any[] = [];

  displayedColumns = [
    'studentName',
    'parentPhone',
    'attendance'
  ];

  attendanceColumns = [
    'studentName',
    'parentPhone',
    'attendance'
  ];

  feesColumns = [
    'studentName',
    'parentPhone',
    'feesDue'
  ];

  examColumns = [
    'studentName',
    'parentPhone',
    'examDate'
  ];

  broadcastColumns = [
    'message'
  ];

  ngOnInit(): void {
    this.loadAttendanceReport();
    this.loadFeesReport();
    this.loadExamReport();
    this.loadBroadcastReport();
  }

  loadAttendanceReport() {
    this.reportsService.attendance().subscribe(result => {
      this.attendanceData = result as any[];
      this.cdr.detectChanges();
    });
  }

  loadFeesReport() {
    this.reportsService.fees().subscribe(result => {
      this.feesData = result as any[];
      this.cdr.detectChanges();
    });
  }

  loadExamReport() {
    this.reportsService.exams().subscribe(result => {
      this.examData = result as any[];
      this.cdr.detectChanges();
    });
  }

  loadBroadcastReport() {
    this.reportsService.broadcast().subscribe(result => {
      this.broadcastData = result as any[];
      this.cdr.detectChanges();
    });
  }

  exportAttendance() {
    this.reportsService.exportAttendance().subscribe(blob => {
      this.downloadFile(blob, 'attendance-report.xlsx');
    });
  }

  exportFees() {
    this.reportsService.exportFees().subscribe(blob => {
      this.downloadFile(blob, 'fees-report.xlsx');
    });
  }

  exportExams() {
    this.reportsService.exportExams().subscribe(blob => {
      this.downloadFile(blob, 'exam-report.xlsx');
    });
  }

  exportBroadcast() {
    this.reportsService.exportBroadcast().subscribe(blob => {
      this.downloadFile(blob, 'broadcast-report.xlsx');
    });
  }

  private downloadFile(blob: Blob, fileName: string) {
    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    a.click();
    window.URL.revokeObjectURL(url);
  }

  exportAttendancePdf() {
    this.reportsService.exportAttendancePdf().subscribe(blob => {
      this.downloadFile(blob,'attendance-report.pdf');
    });
  }

  exportFeesPdf() {
    this.reportsService.exportFeesPdf().subscribe(blob => {
      this.downloadFile(blob,'fees-report.pdf');
    });
  }

  exportExamsPdf() {
    this.reportsService.exportExamsPdf().subscribe(blob => {
      this.downloadFile(blob,'exams-report.pdf');
    });
  }

  exportBroadcastPdf() {
    this.reportsService.exportBroadcastPdf().subscribe(blob => {
      this.downloadFile(blob,'broadcasts-report.pdf');
    });
  }
}