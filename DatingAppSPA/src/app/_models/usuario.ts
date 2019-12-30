import { Foto } from "./foto";

export interface Usuario {

id:number;
username:string;
edad: number;
genero:string;
fechaCreacion:Date;
fechaUltimoIngreso:Date;
ciudad:string;
pais:string;
alias:string;
urlFotoPrincipal:string;
presentacion?:string;
buscando?:string;
interes?:string;
fotos?:Foto[];

}
