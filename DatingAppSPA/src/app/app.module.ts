import { AlertifyService } from './_servicios/alertify.service';
import { AuthService } from './_servicios/auth.service';
import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule, OnInit } from '@angular/core';
import {FormsModule} from '@angular/forms'
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ValorComponent } from './valor/valor.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { RegistroComponent } from './registro/registro.component';
import { ErrorInterceptorProvider } from './_servicios/error.interceptor';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { MiembrosListaComponent } from './miembros-lista/miembros-lista.component';
import { ListaLikesComponent } from './lista-likes/lista-likes.component';
import { MensajesComponent } from './mensajes/mensajes.component';
import {appRoutes} from './routes';
import { UrlSerializer } from '@angular/router';
import { LowerCaseUrlSerializer } from './lowercase-url-serializer';
import { AuthGuard } from './_guards/auth.guard';

@NgModule({
   declarations: [
      AppComponent,
      ValorComponent,
      NavbarComponent,
      HomeComponent,
      RegistroComponent,
      MiembrosListaComponent,
      ListaLikesComponent,
      MensajesComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      Title,
      {//para hacer case insesitve appRoutes
         provide:UrlSerializer,
         useClass:LowerCaseUrlSerializer
       },
       AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { 


}
