import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_servicios/auth.service';
import { AlertifyService } from '../_servicios/alertify.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authsrv: AuthService, private router:Router, private alert: AlertifyService){}
  canActivate(): boolean {
  
    if(this.authsrv.estaLogueado())
    {
      return true;
    }
    
    this.alert.error('No está autorizado.');
    this.router.navigate(['/home']);
    return false;
  }
}
