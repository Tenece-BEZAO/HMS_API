import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { ReactFormModule } from '../shared/modules/react-form/react-form.module';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { SharedModule } from '../shared/shared.module';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { EmailConfirmationComponent } from './email-confirmation/email-confirmation.component';
import { TwoFactorComponent } from './two-factor/two-factor.component';
import { MatIconModule } from '@angular/material/icon';
import { GoogleSigninButtonModule } from '@abacritt/angularx-social-login';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    EmailConfirmationComponent,
    TwoFactorComponent,
    //GoogleSigninButtonModule,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    RouterModule,
    ReactFormModule,
    BsDatepickerModule.forRoot(),
    SharedModule,
    MatIconModule,
    GoogleSigninButtonModule
  ],
  exports: [
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    EmailConfirmationComponent,
    TwoFactorComponent,
  ],
})
export class AuthModule { }
