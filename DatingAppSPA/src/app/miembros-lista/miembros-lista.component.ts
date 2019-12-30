import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../_servicios/usuario.service';
import { AlertifyService } from '../_servicios/alertify.service';
import { Usuario } from '../_models/usuario';

@Component({
  selector: 'app-miembros-lista',
  templateUrl: './miembros-lista.component.html',
  styleUrls: ['./miembros-lista.component.css']
})
export class MiembrosListaComponent implements OnInit {
  lstusuarios: Usuario[];
  constructor(private srvUsuario:UsuarioService, private alertify:AlertifyService) { }

  ngOnInit() {
    this.cargarUsuarios();
  }

  cargarUsuarios(){
  this.srvUsuario.getUsers().subscribe((usuarios:Usuario[])=> {
    this.lstusuarios=usuarios;
  }, error => {
    this.alertify.error(error);
  });

  }

}
