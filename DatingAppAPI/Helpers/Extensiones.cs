using System;
using Microsoft.AspNetCore.Http;

namespace DatingAppAPI.Helpers
{
    //lo hacemos estatico para no tener que creer instancias de los metodos de esta clase

    public static class Extensiones
    {

        public static void AgregarErrorAplicacion (this HttpResponse rta, string msj) {


            rta.Headers.Add("Aplicacion-Error",msj);
            rta.Headers.Add("Access-Control-Expose-Headers","Aplicacion-Error");
            rta.Headers.Add("Access-Control-Allow-Origin","*");
            
        }
        //decimos this xq estamos usamos este metodo desde una clase existente
        public static int CalcularEdad(this DateTime fechaNacimiento){
            int age=0;

            age = DateTime.Today.Year - fechaNacimiento.Year;

            if (fechaNacimiento.AddYears(age)<DateTime.Today)
            age--;

            return age;
        }
        
    }
}