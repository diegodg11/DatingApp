
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-valor',
  templateUrl: './valor.component.html',
  styleUrls: ['./valor.component.css']
})
export class ValorComponent implements OnInit {

 valores: any;

  constructor(private h: HttpClient) { }

  ngOnInit() {

    this.getValores();
  }

  getValores() {
    this.h.get('http://localhost:5000/api/values/all').subscribe(rta => {this.valores=rta;},
    error => {console.log(error);}
    )
  }

}
