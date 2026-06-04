import { Routes } from '@angular/router';

import { MainLayout } from './layout/main-layout/main-layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { UploadCenter } from './pages/upload-center/upload-center';
import { Logs } from './pages/logs/logs';
import { Settings } from './pages/settings/settings';

export const routes: Routes = [
  {
    path: '',
    component: MainLayout,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: Dashboard
      },
      {
        path: 'upload-center',
        component: UploadCenter
      },
      {
        path: 'logs',
        component: Logs
      },
      {
        path: 'settings',
        component: Settings
      }
    ]
  }
];