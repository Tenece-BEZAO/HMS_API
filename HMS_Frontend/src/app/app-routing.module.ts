import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
//import { LoginProviderComponent } from './components/login-provider/login-provider.component';
 import { NotFoundComponent } from './error-pages/not-found/not-found.component';
// import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { PrivacyComponent } from './components/privacy/privacy.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { AdminGuard } from './shared/guards/admin.guard';
import { ContactComponent } from './components/contact/contact.component';
import { AboutComponent } from './components/about/about.component';
import { ServicesComponent } from './components/services/services.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'about', component: AboutComponent },
  { path: 'services', component: ServicesComponent },
  // {
  //   path: 'login-provider',
  //   component: LoginProviderComponent,
  //   canActivate: [AuthGuard],
  // },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
  //{ path: 'company', loadChildren: () => import('./company/company.module').then(m => m.CompanyModule), canActivate: [AuthGuard] },
   { path: '404', component: NotFoundComponent },
  // { path: '500', component: InternalServerComponent },

  { path: '**', redirectTo: '/404', pathMatch: 'full' },
  { path: 'privacy', component: PrivacyComponent },
  { path: 'forbidden', component: ForbiddenComponent },
  {
    path: 'privacy',
    component: PrivacyComponent,
    canActivate: [AuthGuard, AdminGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
