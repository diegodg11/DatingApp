import { AuthService } from './../_servicios/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from '../_servicios/alertify.service';



@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  
  //parentToChild
  @Input() valoresDesdeHome: any;
  //childToParent
  @Output() cancelarRegistro = new EventEmitter();
  modelo: any ={};

  //inyectamos el srv
  constructor(private srv: AuthService, private alertify:AlertifyService) { }

  ngOnInit() {
  }

  ConcretrarRegistro(){

    console.log(this.modelo);
    //para el caso del exito esta vez uso () en vez de una variable por ej rta porq no devuelvo nada
    this.srv.RegistrarNuevoUsuario(this.modelo).subscribe(()=> {
      this.alertify.exito("Registrado!");
      //console.log("Se registró exitosamente")
    },error => {
      this.alertify.error("Error registro");
      
      //console.log(error)
    })
  }

  VolverAHome(){
  
   this.cancelarRegistro.emit(false);
  }


}
