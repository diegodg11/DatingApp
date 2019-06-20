import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  visibilidadFormRegistro=false;
  valores:any;

  constructor(private h: HttpClient) { }

  ngOnInit() {
    this.getValores();
  }

  MostrarFormRegistro(){

    this.visibilidadFormRegistro=true;
  }

  OcultarFormRegistro(rtdoEventoCancelar:boolean){
  return this.visibilidadFormRegistro=rtdoEventoCancelar;

  }


  //este getValores es un ejemplo de comunicacion de componentes parentToChild
  //entre home y registro
  getValores() {
    this.h.get('http://localhost:5000/api/values/all').subscribe(rta => {this.valores=rta;},
    error => {console.log(error);}
    )
  }

}
