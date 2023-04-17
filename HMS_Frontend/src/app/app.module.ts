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
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
