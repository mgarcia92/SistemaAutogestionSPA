import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { serverPath } from '../paths/paths';

@Injectable()
export class EmpresaServiceService {
  private headers : HttpHeaders;
  private path: string = serverPath;
  private mes: number = this.mes;
  private ficha: string = JSON.parse(sessionStorage.getItem("userId")).fichaCd;
 
  constructor(private http:HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.set("Content-Type", "application/applicaton-json")
  }

  public getCumpleanosInfo() {
    let url = `${this.path}/api/EmpresasData/GetCumpleanosInfo`;

    return this.http.get(url, { headers: this.headers })
  }

   public SaveNivel(nivel:any) {
    let url = `${this.path}/api/EmpresasData/SaveNivel`;
    return this.http.post(url,{'FichaCd': nivel.fichaCd,'NivelNbr': nivel.nivelNbr,'nivelOrg' :nivel.nivelOrg},{headers:this.headers});
  }

  //public SaveUsuario(usuario: any) {
  //  let url = `${this.path}/api/EmpresasData/SaveUsuario`;
  //  return this.http.post(url, { 'CedulaNbr': usuario.cedulaNbr,'RoleCd': usuario.roleCd,'ActivoFg': usuario.ActivoFg }, { headers: this.headers });
  //}

}
