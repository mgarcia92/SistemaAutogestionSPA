import { Component, OnInit, Input } from '@angular/core';
import { TrabajadoresService } from '../../services/trabajadores/trabajadores.service';
import { Observable } from 'rxjs/Observable';
import { NivelesInfo } from '../../Models/NivelesInfo';
import { EmpresaServiceService } from '../../services/empresa/empresa-service.service';

@Component({
  selector: 'app-niveles',
  templateUrl: './niveles.component.html',
  styleUrls: ['./niveles.component.css']
})
export class NivelesComponent implements OnInit {
  public nivelesData: NivelesInfo[] = [];
  public fichas :any[];
  public message:string = "";
  public saveSuccess = false;
  constructor(private trabajadoresService: TrabajadoresService,private empresaService: EmpresaServiceService) { }

  ngOnInit() {
    this.getNivelesInfo();
    (window as any).$('.select2').select2({
      allowClear: true
    });
  }

  public sendDataNivel(form){
    this.message = "";
    let fichas = new Array();
    (window as any).$('#fichaId :selected').each(function() {
      let item = (window as any).$(this);
      fichas.push(item.text());
    });

    let NivelNbr = form.value.nivel_usuario
    let NivelOrg = form.value.nivel_organigrama

    if(fichas.length <= 0){
      alert("Por favor seleccione una ficha para continuar");
      return;
    }
    let obj = {fichaCd:fichas,nivelNbr:NivelNbr,nivelOrg:NivelOrg}
    this.empresaService.SaveNivel(obj).subscribe((data:any) => {
      this.getNivelesInfo();
      let count :number = 0;
      data.data.forEach(element => {
        if(element.value == 1)
            count++;
      });
        if(count > 0 ){
          this.saveSuccess = true;
          this.message = `Se Actualizaron ${count} Registros`;
        }
        else{
          this.saveSuccess = false;
          this.message = `Se Actualizaron ${count} Registros`;
        }



    });
  }

  public getNivelesInfo() {
    let response: Observable<Object> = this.trabajadoresService.getNivelesInfo();
    response.subscribe((data: any) => {

      this.nivelesData = data.data;

      this.fichas = data.data.map((item) =>  {
        return{
          key:item.fichaCd,
          value:item.fichaCd
        }
      })

    });
  }

}
