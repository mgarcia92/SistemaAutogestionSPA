import { Component, OnInit } from '@angular/core';

import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';

@Component({
  selector: 'app-personales',
  templateUrl: './personales.component.html',
  styleUrls: ['./personales.component.css']
})

export class PersonalesComponent implements OnInit {
  public info: any = {};
  constructor(private trabajadorService:TrabajadoresService) {

  }

  ngOnInit() {
    this.getPersonalInfo();
  }

  private getPersonalInfo(){
    let personalInfo = this.trabajadorService.getPersonalInfo();
    personalInfo.subscribe((data: any) => {
      //console.log(data)
       this.info = data.data;
    })
  }



}
