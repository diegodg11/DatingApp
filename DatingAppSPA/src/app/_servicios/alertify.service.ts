import { Injectable } from '@angular/core';
//alertifyjs esta incorporado en forma global por lo que no necesitamos declararlo
//pero de esta manera evitamos recibir warnings de angular

declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }
//e es el click en aceptar, okCallback es la funcion que le vamos a pasar como rta
confirmar( msj: string, okCallback: ()=>any){
  alertify.confirmar(msj,function(e){
    if (e) {
      okCallback();
    } else {}
  });  
}

exito(msj: string){
  alertify.success(msj);
   };

error(msj: string){
  alertify.error(msj);
   };

warning(msj: string){
  alertify.warning(msj);
   };

mensaje(msj: string){
  alertify.mensaje(msj);
   };

}
