import { DefaultUrlSerializer, UrlTree } from '@angular/router';
//como angular es casesenstive, de esta manera convertimos todas las peticiones a lowecase
// para que coincida con el las rutas de appRoutes en routes.ts 
// se debe importar en app module
export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
    parse(url: string): UrlTree {
      return super.parse(url.toLowerCase());
    }
}