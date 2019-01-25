import { Component, OnInit } from '@angular/core';
import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';
import { Observable } from 'rxjs/Observable';
import { AumentosInfo } from '../../Models/AumentosInfo';

@Component({
  selector: 'app-aumentoSal',
  templateUrl: './aumentoSal.component.html',
  styleUrls: ['./aumentoSal.component.css']
})
export class AumentosComponent implements OnInit {
  public aumentosData: AumentosInfo[] = [];
  public prueba: string = "";
  constructor(private trabajadoresService:TrabajadoresService) { }

  ngOnInit() {
    this.getAumentosSalInfo();
  }

  public getAumentosSalInfo(){
    let response : Observable<Object> = this.trabajadoresService.getAumentosSalInfo();
    response.subscribe((data: any) => {
      //console.log(data.data);
      this.aumentosData = data.data;
      //console.log(this.aumentosData);
    });
  }
}

