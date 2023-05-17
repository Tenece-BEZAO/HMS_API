import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component'
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { EmailConfirmationComponent } from './email-confirmation/email-confirmation.component';
import { TwoFactorComponent } from './two-factor/two-factor.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: '', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  { path: 'forgotpassword', component: ForgotPasswordComponent },
  { path: 'emailconfirmation', component: EmailConfirmationComponent },
  {path: 'twostepverification', component: TwoFactorComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
