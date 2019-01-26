import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { serverPath } from '../paths/paths';

@Injectable()
export class EmpresaServiceService {
  private headers : HttpHeaders;
  private path: string = serverPath;
  private ficha : string =  JSON.parse(sessionStorage.getItem("userId")).fichaCd;

  constructor(private http:HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.set("Content-Type", "application/applicaton-json")
   }

   public SaveNivel(nivel:any) {
    let url = `${this.path}/api/EmpresasData/SaveNivel`;
    return this.http.post(url,{'FichaCd': nivel.fichaCd,'NivelNbr': nivel.nivelNbr,'nivelOrg' :nivel.nivelOrg},{headers:this.headers});
  }


}
