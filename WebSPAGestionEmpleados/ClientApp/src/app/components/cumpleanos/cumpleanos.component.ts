import { Component, OnInit, Input } from '@angular/core';

import { EmpresaServiceService } from '../../services/empresa/empresa-service.service';
import { Observable } from 'rxjs/Observable';
import { CumpleanosInfo } from '../../Models/CumpleanosInfo';

@Component({
  selector: 'app-cumpleanos',
  templateUrl: './cumpleanos.component.html',
  styleUrls: ['./cumpleanos.component.css']
})
export class CumpleanosComponent implements OnInit {

  public cumpleData: CumpleanosInfo[] = []
  public cumple: any[];
  public message: string = "";
  private table: any;
  private gridCreate = false;
  public rowTable: any = {};

  public NominaDesc = "";
  public FichaNm = "";
  public NacimientoDate = Date;
  
  private jquery: any = (window as any);

  public mes: Number = 0;

  constructor(private empresasService: EmpresaServiceService) {

  }

  ngOnInit() {

    this.getCumpleanosInfo();

  }

  public sendDataCumple(form) {
    this.message = "";
    
    console.log(form)
    let combo: any = document.getElementById("mesId");
    this.mes = combo.value;
    this.getCumpleanosInfo();
  }

  public getCumpleanosInfo() {
    let response: Observable<Object> = this.empresasService.getCumpleanosInfo();
    response.subscribe((data: any) => {

      this.cumpleData = data.data;
      if (!this.gridCreate) {

        let cumpleData: any[] = this.cumpleData.map((obj: CumpleanosInfo) => {
          let object:any = {}
          object.nominaDesc = obj.nominaDesc;
          object.fichaNm = obj.fichaNm;
          let date = new Date(obj.nacimientoDate)
          object.nacimientoDate = `${date.getDate()}  ${date.toLocaleString('es-VE', { month: 'long' })}`

          return object;

        })
        this.gridCreate = this.createTable(cumpleData);
        //this.createEventClickRow();
      }
      else {
        this.table.clear();
        this.table.rows.add(this.cumpleData);
        this.table.draw();
      }

      const monthNames = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
      ];


      this.cumple = monthNames.map((item) => {
        return {
          key: item.toLowerCase(),
          value: item.toLowerCase()
        }
      })
    });
  }

  private createTable(dataGrid: any[]): boolean {
    this.table = this.jquery.$('#tableGridCumpleanos').DataTable({
      columns: [
        { 'data': 'nominaDesc' },
        { 'data': 'fichaNm' },
        { 'data': 'nacimientoDate' }
      ],
      data: dataGrid,
      pageLength: 10
    });

    return true;
  }

  private createEventClickRow() {
    var _this = this
    this.jquery.$('#tableGridCumpleados tbody').on('click', 'tr', function () {
      if (_this.jquery.$(this).hasClass('selected')) {
        _this.jquery.$(this).removeClass('selected');
      }
      else {
        _this.table.$('tr.selected').removeClass('selected');
        _this.jquery.$(this).addClass('selected');
        _this.rowTable = _this.table.row(this).data();
        _this.NominaDesc = _this.rowTable.nominaCd;
        _this.FichaNm = _this.rowTable.fichaNm;
        _this.NacimientoDate = _this.rowTable.nacimientoDate;
        console.log(_this.rowTable);

      }
    });
  }

}
