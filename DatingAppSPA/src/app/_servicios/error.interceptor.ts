import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()
//este archivo o srv se creo directamente como un archivo, sin usar generate srv

export class ErrorInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req).pipe(
            catchError(error => {
                if (error instanceof HttpErrorResponse) {

                    if(error.status===401) { //devuelve errores de no autorizado
                    return throwError(error.statusText);
                }
                    //errores con header aplicacion-error
                    const aplicacionError = error.headers.get('Aplicacion-Error');
                    if (aplicacionError) {
                        return throwError(aplicacionError);
                    }
                    
                    const serverError= error.error;
                    let modalStateErrors=''; //devuelve lista de errores del modelo
                    if(serverError && typeof serverError==='object'){
                        for(const key in serverError){
                            if(serverError[key]){
                             modalStateErrors += serverError[key] +'\n';
                            }
                        }
                    }

                    return throwError(modalStateErrors || serverError || 'Server Error');
                }
            }

            )
        );


    }

}
export const ErrorInterceptorProvider={
    provide:HTTP_INTERCEPTORS,
    useClass:ErrorInterceptor,
    multi:true
}