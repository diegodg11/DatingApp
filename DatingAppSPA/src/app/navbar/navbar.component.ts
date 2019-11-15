import { AlertifyService } from './../_servicios/alertify.service';

import { AuthService } from './../_servicios/auth.service';
import { Component, OnInit } from '@angular/core';
import { UpperCasePipe } from '@angular/common';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

 modelo:any = {};


 // esto es DI
  constructor( public srv: AuthService, private alertify: AlertifyService, private router: Router) { }


  ngOnInit() {
  }

//verifica si el usuario esta logueado
  estaLogueado(){

    //reemplazamos el codigo anterior por este que utiliza la libreria de auth0
  
    return this.srv.estaLogueado();

    
    //ya no lo uso porque utilizo Auth0
    //const token = localStorage.getItem("tokenrtdo");
    // if (token)
    // return true
    // else return false

  }

  //metodo para desloguearse, eliminando el token
  desloguearse() {

  localStorage.removeItem("tokenrtdo");
  this.alertify.warning("Deslogueado");
  this.router.navigate(['/home']);
  }


  //metodo utilizado para loguearse
  loguearse() {
  //  console.log(this.modelo);
    this.srv.login(this.modelo).subscribe(
      r => { this.alertify.exito("Logueado!");},
      err => {
        if(err==="Unauthorized")
        err="No Autorizado";
        this.alertify.error(err);
      }, 
      //esta es la ultimo opcion de un observable, cuando se completa
      () => this.router.navigate(['/miembros'])

      );  
  }


}
