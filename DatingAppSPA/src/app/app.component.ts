import { Component, OnInit } from '@angular/core';
import { AuthService } from './_servicios/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'Private Place';
  jwtHelper = new JwtHelperService();

  constructor(private srvAuth:AuthService, private titulo:Title){}
  
  
  public setTitulo( tituloNuevo: string) {
    this.titulo.setTitle( tituloNuevo);
  }

  ngOnInit(){

    //cambio titulo usando el srv de angular
      this.setTitulo("Private Place");
      
    const token = localStorage.getItem("tokenrtdo");
    // este metodo es necesario porque desde el componente navbar
    // requerimos el token decodificado para acceder al nombre de usuario y mostrarlo
    // para que este disponible aun cuando se refresca la pagina necesitamos que este en un componente de mayor
    // jerarquia, y appcomponent es el componente padre mas arriba
    if(token){

      this.srvAuth.tokenDecodificado= this.jwtHelper.decodeToken(token);
    }

  }
}
