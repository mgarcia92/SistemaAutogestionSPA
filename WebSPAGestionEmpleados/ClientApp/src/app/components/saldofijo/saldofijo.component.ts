import { Component, OnInit } from '@angular/core';
import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';
import { Observable } from 'rxjs/Observable';
import { SaldoFijoInfo } from '../../Models/saldoFijoInfo';

@Component({
  selector: 'app-saldofijo',
  templateUrl: './saldofijo.component.html',
  styleUrls: ['./saldofijo.component.css']
})
export class SaldofijoComponent implements OnInit {
  public saldosData: SaldoFijoInfo [] = [];
  constructor(private trabajadoresService: TrabajadoresService) { }

  ngOnInit() {
    this.getSaldosFijoInfo()
  }
  public getSaldosFijoInfo() {
    let response: Observable<Object> = this.trabajadoresService.getSaldosFijoInfo();
    response.subscribe((data: any) => {
      console.log(data.data);
      this.saldosData = data.data;
      //console.log(this.saldosData);
    });

  }

}
