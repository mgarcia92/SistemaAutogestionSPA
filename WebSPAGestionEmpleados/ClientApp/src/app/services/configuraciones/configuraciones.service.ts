import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { serverPath } from '../paths/paths';

@Injectable()
export class ConfiguracionesService {

  private headers: HttpHeaders;
  private path: string = serverPath;
  private cedula: string = JSON.parse(sessionStorage.getItem("cedulaId")).cedulaNbr;
  private estatu: string;
  
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.set("Content-Type", "application/applicaton-json");
  }

  public getUsuariosInfo() {
    let url = `${this.path}/api/ConfiguracionData/GetUsuariosInfo?cedula=${this.cedula}`;
    return this.http.get(url, { headers: this.headers });
  }

  public SaveUsuario(usuario: any) {
    let url = `${this.path}/api/ConfiguracionData/SaveUsuario`;
    console.log(usuario)
    return this.http.post(url, { 'cedulaNbr': usuario.cedulaNbr, 'roleCd': usuario.roleCd, 'activoFg': usuario.activoFg }, { headers: this.headers });
  }

  //Roles
  public getRolesInfo() {
    let url = `${this.path}/api/ConfiguracionData/GetRolesInfo?cedula=${this.cedula}`;
    return this.http.get(url, { headers: this.headers });
  }
  public SaveRol(rol: any) {
    let url = `${this.path}/api/ConfiguracionData/SaveRol`;
    console.log(rol)
    return this.http.post(url, { 'roleCd': rol.roleCd, 'roleDesc': rol.roleDesc, 'activoFg': rol.activoFg }, { headers: this.headers });
  }
  public DeleteRol(rol: any) {
    let url = `${this.path}/api/ConfiguracionData/DeleteRol`;
    console.log(rol)
    return this.http.post(url, { 'roleCd': rol.roleCd}, { headers: this.headers });
  }

  public getFuncionesInfo() {
    
    //let url = `${this.path}/api/ConfiguracionData/GetFuncionesInfo()`;
    let url = `${this.path}/api/ConfiguracionData/GetFuncionesInfo?cedula=${this.cedula}`;
    return this.http.get(url, { headers: this.headers });

  }

  public getEstatusInfo() {
    let url = `${this.path}/api/ConfiguracionData/GetEstatusInfo?estatu=${this.estatu}`;
    return this.http.get(url, { headers: this.headers });
  }


  public getRolesAutocomplete() {
    let url = `${this.path}/api/ConfiguracionData/GetRolAutocomplete`;
    return this.http.get(url,{ headers: this.headers });
  }

}
