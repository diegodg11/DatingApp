import { AuthService } from './_servicios/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { ValorComponent } from './valor/valor.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { RegistroComponent } from './registro/registro.component';
import { ErrorInterceptorProvider } from './_servicios/error.interceptor';

@NgModule({
   declarations: [
      AppComponent,
      ValorComponent,
      NavbarComponent,
      HomeComponent,
      RegistroComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
