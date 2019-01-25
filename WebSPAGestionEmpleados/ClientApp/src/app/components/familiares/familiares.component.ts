import { Component, OnInit } from '@angular/core';
import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';
import { Observable } from 'rxjs/Observable';
import { FamiliarInfo } from '../../Models/FamiliarInfo';

@Component({
  selector: 'app-familiares',
  templateUrl: './familiares.component.html',
  styleUrls: ['./familiares.component.css']
})
export class FamiliaresComponent implements OnInit {
  public familiarData : FamiliarInfo[] = [];
  constructor(private trabajadoresService:TrabajadoresService) { }

  ngOnInit() {
    this.getFamiliarInfo();
  }

  public getFamiliarInfo(){
    let response : Observable<Object> = this.trabajadoresService.getFamiliarInfo();
    response.subscribe((data:any) => {
      this.familiarData = data.data;
    });
  }
}

