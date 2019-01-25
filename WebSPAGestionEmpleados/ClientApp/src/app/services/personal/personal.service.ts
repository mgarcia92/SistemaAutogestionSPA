import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PersonalService {
  private headers: HttpHeaders;
  constructor(private http:HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.set("Content-Type", "application/applicaton-json");
  }

  public getPersonalInfo() {
    let ficha: string =  JSON.parse(sessionStorage.getItem("userId")).fichaCd;
    let url = 'http://localhost:52490/api/TrabajadorData/GetPersonalInfo?ficha=' + ficha;
    return this.http.get(url,{headers:this.headers});
  }



}
