import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MensajesComponent } from './mensajes/mensajes.component';
import { ListaLikesComponent } from './lista-likes/lista-likes.component';
import { MiembrosListaComponent } from './miembros-lista/miembros-lista.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes =[
    
{path:'', component:HomeComponent},
//esta seria una manera de proteger todas las rutas 
// {
//     path:'',
//     runGuardsAndResolvers:'always',
//     canActivate:[AuthGuard],
//     children:[
//         {path:'mensajes', component:MensajesComponent},
// {path:'likes', component:ListaLikesComponent},
// {path:'miembros', component:MiembrosListaComponent}
//     ]

// },
{path:'mensajes', component:MensajesComponent},
{path:'likes', component:ListaLikesComponent},
{path:'miembros', component:MiembrosListaComponent, canActivate:[AuthGuard]},
{path:'**', redirectTo:'', pathMatch:'full'}


];