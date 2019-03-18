import { Component, OnInit, Input } from '@angular/core';
//import { NgModule } from '@angular/core';
//import { FormsModule } from '@angular/forms';
//import { FormArray } from '@angular/forms';

import { ConfiguracionesService } from '../../services/configuraciones/configuraciones.service';
import { Observable } from 'rxjs/Observable';
import { UsuariosInfo } from '../../Models/UsuariosInfo';
import { EstatusInfo } from '../../Models/EstatusInfo';
//import { setTimeout } from 'timers';
//import { loadavg } from 'os';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuarioComponent implements OnInit {

  public cedulasData: UsuariosInfo[] = [];
  public cedulas: any[];
  public estatusData: EstatusInfo[] = [];
  public estatus: any[];
  public message: string = "";
  private table: any;
  public saveSuccess = false;
  private gridCreate = false;
  public rowTable: any = {};
  public CedulaNbr: any= "";
  public RoleCd: any= "";
  public ActivoDesc: any = "";
  private jquery: any = (window as any);
  

  constructor(private configuracionesService: ConfiguracionesService) {

  }

  ngOnInit() {

    this.getUsuariosInfo();

    this.getEstatusInfo();
    (window as any).$('.select2').select2({
      allowClear: true
    });  
  }
  
  public sendDataUsuario(form) {
    this.message = "";
    //let prueba = $("#select2").val();
    let estatus = new Array();
    (window as any).$('#estatuId :selected').each(function () {
      let item = (window as any).$(this);
      estatus.push(item.val());
      this.ActivoFg = (item.index());
      console.log(this.ActivoFg)
    });


    console.log(form)
    let combo:any  = document.getElementById("estatuId");
    let obj = { cedulaNbr: this.CedulaNbr, roleCd: this.RoleCd, activoFg: combo.selectedIndex, activoDesc: this.ActivoDesc }
    //let obj = { cedulaNbr: this.CedulaNbr, roleCd: this.RoleCd, activoFg: this.activoSuccess }
    this.configuracionesService.SaveUsuario(obj).subscribe((data: any) => {
           
      if (data.data) {
        this.saveSuccess = true;
        this.message = `Se Actualizo Correctamente el Registro...`;
        this.getUsuariosInfo();
        this.RoleCd = "";
        this.CedulaNbr = "";
        //this.ActivoFg = "";
        this.ActivoDesc = "";
        //this.estatus = [];
        combo.selecteIndex = 0;
        

        
      }
      else {
        this.saveSuccess = false;
        this.message = `No Actualizo Correctamente el Registro...`;
      }
    });
  }
  
  public  getUsuariosInfo() {
    let response: Observable<Object> = this.configuracionesService.getUsuariosInfo();
    response.subscribe((data: any) => {

      this.cedulasData = data.data;
      if (!this.gridCreate) {
        this.gridCreate = this.createTable(this.cedulasData);
        this.createEventClickRow();
      }
      else {
        this.table.clear();
        this.table.rows.add(this.cedulasData);
        this.table.draw();
      }

      this.cedulas = data.data.map((item) => {
        return {
          key: item.cedulaNbr + "  " + item.fichaNm,
          value: item.cedulaNbr
        }
      })
    });
  }
  
  private createTable(dataGrid: UsuariosInfo[]): boolean {
   this.table =  this.jquery.$('#tableGridUsuarios').DataTable({
      columns: [
        { 'data': 'cedulaNbr' },
        { 'data': 'fichaNm' },
        { 'data': 'roleCd' },
        //{ 'data': 'activoFg' },
        { 'data': 'activoDesc' }
      ],
      data: dataGrid,
      pageLength: 10
    });

    return true;
  }

  private createEventClickRow() {
    var _this = this
    this.jquery.$('#tableGridUsuarios tbody').on('click', 'tr', function () {
      if (_this.jquery.$(this).hasClass('selected')) {
        _this.jquery.$(this).removeClass('selected');
      }
      else {
        _this.table.$('tr.selected').removeClass('selected');
        _this.jquery.$(this).addClass('selected');
        _this.rowTable = _this.table.row(this).data();
        _this.CedulaNbr = _this.rowTable.cedulaNbr;
        _this.RoleCd = _this.rowTable.roleCd;
        //_this.ActivoFg = _this.rowTable.activoFg;
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
      .subscribe((data:any) => {
          this.createAutocomplete(data.data)
      })
  }

    public loadAutoComplete(e: any) {    
    this.getRolesAutocompleteData();
  }

  public getEstatusInfo() {
    let response: Observable<Object> = this.configuracionesService.getEstatusInfo();
    response.subscribe((data2: any) => {

      //this.estatusData = data2.data;

      this.estatus = data2.data.map((item) => {
        return {
          key: item.itemNbr,
          value: item.tablaDesc
        }
      })

      this.estatusData = this.estatus;

    });
  }

}
