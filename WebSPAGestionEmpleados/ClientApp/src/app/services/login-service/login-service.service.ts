import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { serverPath } from '../paths/paths';

@Injectable()
export class LoginServiceService {
  private headers: HttpHeaders;
  public username : string;
  private path : string = serverPath;
  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.set("Content-Type", "application/applicaton-json");
   }

  logonUser(username: string, passwrod: string) {
    this.username = username;
    let url =  `${this.path}/api/LoginApi/Logon`;
    let body = {LoginUsr : username, LoginPwd: passwrod};
    return this.http.post(url,body,{headers:this.headers});
  }

  logout(username: string) {
    let url = `${this.path}/api/LoginApi/Logout?username=${username}`;
    return this.http.get(url,{headers:this.headers});
  }

  getUserId(): string {
    let user = JSON.parse(sessionStorage.getItem("userId"));
    return user.loginUsr;
  }

  getCedId(): string {
    let user = JSON.parse(sessionStorage.getItem("cedulaId"));
    return user.loginUsr;
  }

  getUserInfo(): any {
    let user = JSON.parse(sessionStorage.getItem("userId"));
    return user;
  }

  sessionStatus(username: string) {
    let url = `${this.path}/api/LoginApi/SessionStatus?username=${username}`;
    return this.http.get(url,{headers:this.headers});
  }

}
