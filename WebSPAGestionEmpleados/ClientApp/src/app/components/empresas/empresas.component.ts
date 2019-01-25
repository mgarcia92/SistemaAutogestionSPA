import { Component, OnInit } from '@angular/core';
import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';
import { Observable } from 'rxjs/Observable';
import { EmpresasInfo } from '../../Models/EmpresasInfo';

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.css']
})
export class EmpresasComponent implements OnInit {
  public empresasData : EmpresasInfo = {
    fichaCd: "",
    departamento: "",
    cargo : "",
    ingresoDate: null,
    jefe: "",
    sueldo3Sal: 0
  };
  constructor(private trabajadoresService:TrabajadoresService) { }

  ngOnInit() {
    this.getEmpresasInfo();
  }

  public getEmpresasInfo(){
    let response : Observable<Object> = this.trabajadoresService.getEmpresasInfo();
    response.subscribe((data:any) => {
     // console.log(data.data)
      this.empresasData = data.data;
     // console.log(this.empresasData)
    });
  }
}
