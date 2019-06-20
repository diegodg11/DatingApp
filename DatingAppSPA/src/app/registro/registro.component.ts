import { AuthService } from './../_servicios/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';



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
  constructor(private srv: AuthService) { }

  ngOnInit() {
  }

  ConcretrarRegistro(){
    console.log(this.modelo);
    //para el caso del exito esta vez uso () en vez de una variable por ej rta porq no devuelvo nada
    this.srv.RegistrarNuevoUsuario(this.modelo).subscribe(()=> {
      console.log("Se registró exitosamente")
    },error => {
      console.log(error)
    })
  }

  VolverAHome(){
  
   this.cancelarRegistro.emit(false);
  }


}
