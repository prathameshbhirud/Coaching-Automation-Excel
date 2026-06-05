import {ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BaseChartDirective } from 'ng2-charts';
import { Chart, registerables } from 'chart.js';

import { DashboardService } from '../../core/services/dashboard.service';
import { LogsService } from '../../core/services/logs.service';
import { StatisticsService } from '../../core/services/statistics.service';

Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule, RouterModule, BaseChartDirective],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.scss']
})
export class Dashboard implements OnInit {

  private dashboardService = inject(DashboardService);
  private cdr = inject(ChangeDetectorRef);
  private logsService = inject(LogsService);
  private statisticsService = inject(StatisticsService);

  summary: any;
  activities: any[] = [];
  stats: any;
  trendData: any = {
    labels: [],
    datasets: []
  };

  ngOnInit(): void {
    this.loadSummary();
    this.loadActivities();
    this.loadStatistics();
    this.loadAttendanceTrend();
  }

  loadSummary() {
    this.dashboardService.getSummary().subscribe(result => {
      this.summary = result;
      this.cdr.detectChanges();
    });
  }

  loadActivities() {
    this.logsService.getRecent().subscribe(result => {
      this.activities = result as any[];
      this.cdr.detectChanges();
    });
  }

  loadStatistics() {
    this.statisticsService.getStats().subscribe(result => {
      this.stats = result;
      this.cdr.detectChanges();
    });
  }

  loadAttendanceTrend() {
    this.statisticsService.getAttendanceTrend().subscribe((result: any) => {
      this.trendData = {
        labels: result.map((x: any) => x.date),
                  datasets: [
                    {
                      label: 'Attendance',
                      data: result.map((x: any) => x.count)
                    }
                  ]
        };
        this.cdr.detectChanges();
    });
  }
}