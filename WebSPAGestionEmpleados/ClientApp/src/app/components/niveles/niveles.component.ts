import { Component, OnInit, Input } from '@angular/core';
import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';
import { Observable } from 'rxjs/Observable';
import { NivelesInfo } from '../../Models/NivelesInfo';

@Component({
  selector: 'app-niveles',
  templateUrl: './niveles.component.html',
  styleUrls: ['./niveles.component.css']
})
export class NivelesComponent implements OnInit {
  public nivelesData: NivelesInfo[] = [];
  constructor(private trabajadoresService: TrabajadoresService) { }

  ngOnInit() {
    this.getNivelesInfo()
  }

  public getNivelesInfo() {
    let response: Observable<Object> = this.trabajadoresService.getNivelesInfo();
    response.subscribe((data: any) => {
      console.log(data.data);
      this.nivelesData = data.data;
    });
  }

}
