import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { serverPath } from '../paths/paths';

@Injectable()
export class TrabajadoresService {
  private headers : HttpHeaders;
  private path: string = serverPath;
  private ficha: string = JSON.parse(sessionStorage.getItem("userId")).fichaCd;
  private cedula: string = JSON.parse(sessionStorage.getItem("cedulaId")).cedulaNbr;
  constructor(private http:HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.set("Content-Type", "application/applicaton-json");
  }

  public getPersonalInfo() {
    let url = `${this.path}/api/TrabajadorData/GetPersonalInfo?ficha=${this.ficha}`;
    return this.http.get(url,{headers:this.headers});
  }

  public getFamiliarInfo(){
    let url = `${this.path}/api/TrabajadorData/GetFamiliarInfo?ficha=${this.ficha}`;
    return this.http.get(url,{headers:this.headers})
  }

  public getEmpresasInfo(){
    let url = `${this.path}/api/TrabajadorData/GetEmpresasInfo?ficha=${this.ficha}`;
    return this.http.get(url,{headers:this.headers})
  }

  public getAumentosSalInfo() {
    let url = `${this.path}/api/TrabajadorData/GetAumentosSalInfo?ficha=${this.ficha}`;
    return this.http.get(url, { headers: this.headers });
  }

  public getSaldosFijoInfo() {
    let url = `${this.path}/api/TrabajadorData/getSaldosFijoInfo?ficha=${this.ficha}`;
    return this.http.get(url, { headers: this.headers });
  }

  public getNivelesInfo() {
    let url = `${this.path}/api/TrabajadorData/getNivelesInfo?ficha=${this.ficha}`;
    return this.http.get(url, { headers: this.headers });
  }

  //public getUsuariosInfo() {
  //  let url = `${this.path}/api/TrabajadorData/getUsuariosInfo?cedula=${this.cedula}`;
  //  return this.http.get(url, { headers: this.headers });
  //}

}
