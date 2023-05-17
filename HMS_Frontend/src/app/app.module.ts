import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginProviderComponent } from './components/login-provider/login-provider.component';
import { ProviderProfileComponent } from './components/provider-profile/provider-profile.component';
import { ProvidersListComponent } from './components/providers-list/providers-list.component';
import { ProviderDetailsComponent } from './components/provider-details/provider-details.component';
import { EditProviderComponent } from './components/edit-provider/edit-provider.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { ServicesComponent } from './components/services/services.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthModule } from './auth/auth.module';
import { ReactFormModule } from './shared/modules/react-form/react-form.module';
import { DatePipe } from '@angular/common';
import { ErrorHandlerService } from './shared/services/error-handler.service';
//import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './shared/guards/auth.guard';
import { PrivacyComponent } from './components/privacy/privacy.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
// import { authInterceptorProviders } from './_helpers/auth.interceptor';

export function tokenGetter() {
  return localStorage.getItem('token');
}
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    //GetStartedConponent,
    LoginProviderComponent,
    ProviderProfileComponent,
    ProvidersListComponent,
    ProviderDetailsComponent,
    EditProviderComponent,
    ServicesComponent,
    ContactComponent,
    NotFoundComponent,
    PrivacyComponent,
    ForbiddenComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatDividerModule,
    HttpClientModule,
    AuthModule,
    ReactFormModule,
    // JwtModule.forRoot({
    //   config: {
    //     tokenGetter: tokenGetter,
    //     allowedDomains: ['localhost:7258', 'localhost:7297'],
    //     disallowedRoutes: [],
    //   },
    // }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true,
    },
    DatePipe,
    AuthGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
