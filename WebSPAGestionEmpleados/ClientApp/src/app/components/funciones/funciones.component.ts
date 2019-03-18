import { Component, OnInit, Input } from '@angular/core';

//import { NgModule } from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';
//import { FormsModule, NgSelectOption } from '@angular/forms';


import { ConfiguracionesService } from '../../services/configuraciones/configuraciones.service';
import { Observable } from 'rxjs/Observable';
import { FuncionesInfo } from '../../Models/FuncionesInfo';
import { EstatusInfo } from '../../Models/EstatusInfo';

@Component({
  selector: 'app-Funciones',
  templateUrl: './Funciones.component.html',
  styleUrls: ['./Funciones.component.css']
})

//@NgModule({
//  imports: [BrowserModule, FormsModule, NgSelectOption],
//  })

export class FuncionesComponent implements OnInit {

  public funcionesData: FuncionesInfo[] = [];
  public funciones: any[];
  public estatusData: EstatusInfo[] = [];
  public estatus: any[];
  public message: string = "";
  private table: any;
  public saveSuccess = false;
  private gridCreate = false;
  public rowTable: any = {};
  public RoleCd: any = "";
  public RoleDesc: any = "";
  public ActivoDesc: any = "";
  private jquery: any = (window as any);

  constructor(private configuracionesService: ConfiguracionesService) { }

  ngOnInit() {

    this.getFuncionesInfo();

    this.getEstatusInfo();
    (window as any).$('.select2').select2({
      allowClear: true
    });
  }
  
  public sendDataFuncion(form) {
    this.message = "";
    (window as any).$('#estatuId :selected').each(function () {
    });


    console.log(form)

    let obj = { roleCd: this.RoleCd, roleDesc: this.RoleDesc, activoFg: 0 }
    this.configuracionesService.SaveFuncion(obj).subscribe((data: any) => {

      if (data.data) {
        this.saveSuccess = true;
        this.message = `Se Actualizo Correctamente el Registro...`;
        this.getFuncionesInfo();
        this.RoleCd = "";
        this.RoleDesc = "";
        this.ActivoDesc = "";
      }
      else {
        this.saveSuccess = false;
        this.message = `No Actualizo Correctamente el Registro...`;
      }
    });
  }

  public getFuncionesInfo() {
    let response: Observable<Object> = this.configuracionesService.getFuncionesInfo();
    response.subscribe((data: any) => {

      this.funcionesData = data.data;
      if (!this.gridCreate) {
        this.gridCreate = this.createTable(this.funcionesData);
        this.createEventClickRow();
      }
      else {
        this.table.clear();
        this.table.rows.add(this.funcionesData);
        this.table.draw();
      }

      this.funciones = data.data.map((item) => {
        return {
          key: item.roleCd,
          value: item.roleDesc
        }
      })
    });
  }

  private createTable(dataGrid: FuncionesInfo[]): boolean {
    this.table = this.jquery.$('#tableGridFunciones').DataTable({
      columns: [
        { 'data': 'roleCd' },
        { 'data': 'roleDesc' },
        { 'data': 'activoDesc' }
      ],
      data: dataGrid,
      pageLength: 10
    });

    return true;
  }

  private createEventClickRow() {
    var _this = this
    this.jquery.$('#tableGridFunciones tbody').on('click', 'tr', function () {
      if (_this.jquery.$(this).hasClass('selected')) {
        _this.jquery.$(this).removeClass('selected');
      }
      else {
        _this.table.$('tr.selected').removeClass('selected');
        _this.jquery.$(this).addClass('selected');
        _this.rowTable = _this.table.row(this).data();
        _this.RoleCd = _this.rowTable.roleCd;
        _this.RoleDesc = _this.rowTable.roleDesc;
        _this.ActivoDesc = _this.rowTable.activoDesc;
        console.log(_this.rowTable)
      }
    });

  }

  private createAutocomplete(data: any) {
    console.log(data)
    let _this = this
    this.jquery.$("#role").autocomplete({
      source: data,
      minLength: 0
    }).focus(function () {
      _this.jquery.$(this).autocomplete("search");
    })
  }

  public getRolesAutocompleteData() {
    this.configuracionesService.getRolesAutocomplete()
      .subscribe((data: any) => {
        this.createAutocomplete(data.data)
      })
  }

  public loadAutoComplete(e: any) {
    this.getRolesAutocompleteData();
  }

  public getEstatusInfo() {
    let response: Observable<Object> = this.configuracionesService.getEstatusInfo();
    response.subscribe((data2: any) => {

      this.estatusData = data2.data;

      this.estatus = data2.data.map((item) => {
        return {
          key: item.itemNbr,
          value: item.tablaDesc
        }
      })

    });
  }

}
