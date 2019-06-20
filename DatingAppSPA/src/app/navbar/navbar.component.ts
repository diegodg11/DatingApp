
import { AuthService } from './../_servicios/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

 modelo:any = {};

 // esto es DI
  constructor( private srv: AuthService) { }


  ngOnInit() {
  }

//verifica si el usuario esta logueado
  estaLogueado(){
    const token = localStorage.getItem("tokenrtdo");

    if (token)
    return true
    else return false

  }

  //metodo para desloguearse, eliminando el token
  desloguearse() {

    localStorage.removeItem("tokenrtdo");
  }


  //metodo utilizado para loguearse
  loguearse() {
    console.log(this.modelo);
    this.srv.login(this.modelo).subscribe(
      r => { console.log("se pudo loguear");},
      err => {console.log(err)}
      
      );  
  }
}
