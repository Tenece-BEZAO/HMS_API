import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterProviderComponent } from './components/register-provider/register-provider.component';
import { LoginProviderComponent } from './components/login-provider/login-provider.component';
import { ProviderProfileComponent } from './components/provider-profile/provider-profile.component';
import { ProvidersListComponent } from './components/providers-list/providers-list.component';
import { ProviderDetailsComponent } from './components/provider-details/provider-details.component';
import { EditProviderComponent } from './components/edit-provider/edit-provider.component';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthModule } from './auth/auth.module';
import { ReactFormModule } from './shared/modules/react-form/react-form.module';
import { RepositoryService } from './shared/services/repository.service';
import { DatePipe } from '@angular/common';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './shared/guards/auth.guard';
import { PrivacyComponent } from './components/privacy/privacy.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
// import { authInterceptorProviders } from './_helpers/auth.interceptor';

export function tokenGetter() {
  return localStorage.getItem("token");
}
@NgModule({
  declarations: [
    AppComponent,
    RegisterProviderComponent,
    LoginProviderComponent,
    ProviderProfileComponent,
    ProvidersListComponent,
    ProviderDetailsComponent,
    EditProviderComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    NavbarComponent,
    NotFoundComponent,
    PrivacyComponent,
    ForbiddenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CollapseModule.forRoot(),
     AuthModule,
    ReactFormModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7258"],
        disallowedRoutes: []
      }
    })

  ],
 
  
  // JwtModule.forRoot({
  //   config: {
  //     tokenGetter: tokenGetter,
  //     allowedDomains: ["localhost:5001"],
  //     disallowedRoutesRoutes: []
  //   },
  // }),
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true,
    },
    DatePipe,
    AuthGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
