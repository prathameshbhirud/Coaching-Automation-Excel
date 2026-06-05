import { ChangeDetectorRef, Component, Inject, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';

import { ReportsService } from '../../core/services/reports.service';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [
    CommonModule,
    MatTabsModule,
    MatTableModule
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
}