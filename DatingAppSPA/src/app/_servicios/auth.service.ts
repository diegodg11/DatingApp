import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url="http://localhost:5000/api/auth/";

constructor(private h:HttpClient) { }

//metodo para registrar un nuevo usuario 
RegistrarNuevoUsuario(modelo:any) {

  return this.h.post(this.url+'registrar',modelo); 
}


// este metodo usamos para loguearnos

//modelo es lo que pasamos desde el formulario login
login(modelo:any){
  //esta primera linea devuelve un objeto como observable
  return this.h.post(this.url+'login',modelo)
  //usamos rxjs para poder trabajar con el observable que obtenemos
  .pipe(
    map((rta:any)=> {
      const usr =  rta;
      //si usuario no viene vacio
    
      if (usr) {
          //sabemos por la api q obtenemos un token
          //lo guardamos en el localstorage
        localStorage.setItem('tokenrtdo',usr.token);
      }
    }
    
    )
  );
}

}
