import { Routes } from '@angular/router';

import { MainLayout } from './layout/main-layout/main-layout';
import { Dashboard } from './pages/dashboard/dashboard';
import { UploadCenter } from './pages/upload-center/upload-center';
import { Logs } from './pages/logs/logs';
import { Settings } from './pages/settings/settings';
import { Reports } from './pages/reports/reports';
import { Login } from './features/login/login';
import { authGuard } from './core/auth/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: MainLayout,
    children: [
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: Dashboard,
        canActivate: [authGuard]
      },
      {
        path: 'upload-center',
        component: UploadCenter,
        canActivate: [authGuard]
      },
      {
        path: 'logs',
        component: Logs,
        canActivate: [authGuard]
      },
      {
        path: 'settings',
        component: Settings,
        canActivate: [authGuard]
      },
      {
        path: 'reports',
        component: Reports,
        canActivate: [authGuard]
      },
      {
        path: 'login',
        component: Login
      },
      {
        path: '**',
        redirectTo: 'login'
      }
    ]
  }
];