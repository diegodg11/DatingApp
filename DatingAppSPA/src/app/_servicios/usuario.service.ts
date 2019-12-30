import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../_models/usuario';


const httpOptions={

  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('tokenrtdo')
  })
};


@Injectable({
  providedIn: "root"
})


export class UsuarioService {
  

  url:string = environment.baseURLapi+'';

constructor(private h:HttpClient) { }


getUsers(): Observable<Usuario[]> {

  return this.h.get<Usuario[]>(this.url+'users',httpOptions);
}

getUser(id:number):Observable<Usuario>{

  return this.h.get<Usuario>(this.url+'users/'+id,httpOptions);
}

}
