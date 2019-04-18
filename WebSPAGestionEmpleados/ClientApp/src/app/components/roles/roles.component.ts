import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ConfiguracionesService } from '../../services/configuraciones/configuraciones.service';
import { Observable } from 'rxjs/Observable';

import { RolesInfo } from '../../Models/RolesInfo';
import { EstatusInfo } from '../../Models/EstatusInfo';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {

  public rolesData: RolesInfo[] = [];
  public roles: any[];
  public estatusData: EstatusInfo[] = [];
  public estatus: any[];
  public message: string = "";
  
  public saveSuccess = false;

  public rowTable: any = {};
  public RoleCd: any = "";
  public RoleDesc: any = "";
  public ActivoDesc: any = "";

  private table: any;
  private gridCreate = false;
  private jquery: any = (window as any);

  id: string;

  constructor(private configuracionesService: ConfiguracionesService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {

    this.id = this.route.snapshot.params['id'];

    this.getRolesInfo();

    this.getEstatusInfo();
    (window as any).$('.select2').select2({
      allowClear: true
    });  

  }


  public deleteRol() {
    let obj = { roleCd: this.RoleCd }
    console.log(obj,"deleteRol")
    //Eliminar
    this.configuracionesService.DeleteRol(obj).subscribe((data: any) => {
      if (data.data) {
        this.saveSuccess = true;
        this.message = data.message != '' ? data.message : `Se Eliminó Correctamente el Registro...`;
        this.getRolesInfo();
        this.RoleCd = "";
        this.RoleDesc = "";
        this.ActivoDesc = "";
        this.estatus = [];
        //this.getEstatusInfo();
        //(window as any).$('.select2').select2({
        //  allowClear: true
        //});
      }
      else {
        this.saveSuccess = false;
        this.message = `No Eliminó Correctamente el Registro...`;
      }
    });


  }

  public sendDataRol(form) {
    this.message = "";
    let estatus = new Array();
    (window as any).$('#estatuId :selected').each(function () {
      let item = (window as any).$(this);
    });
    console.log(form)
    let combo: any = document.getElementById("estatuId");
    let btnAgregar: any = document.getElementById("guardarId");
    let btnEliminar: any = document.getElementById("eliminarId");

    //let bntxxx: any = document.getSelection()
    let obj = { roleCd: this.RoleCd, roleDesc: this.RoleDesc, activoFg: (window as any).$('#estatuId').select2('val') }
    this.configuracionesService.SaveRol(obj).subscribe((data: any) => {

      if (data.data) {
        this.saveSuccess = true;
        this.message = `Se Actualizo Correctamente el Registro...`;
        this.getRolesInfo();
        this.RoleCd = "";
        this.RoleDesc = "";
        this.ActivoDesc = "";
        this.estatus = [];
        this.getEstatusInfo();
        (window as any).$('.select2').select2({
          allowClear: true
        });
        
      }
      else {
        this.saveSuccess = false;
        this.message = `No Actualizo Correctamente el Registro...`;
      }
    });



  }

  public getRolesInfo() {
    let response: Observable<Object> = this.configuracionesService.getRolesInfo();
    response.subscribe((data: any) => {

      this.rolesData = data.data;
      if (!this.gridCreate) {
        this.gridCreate = this.createTable(this.rolesData);
        this.createEventClickRow();
      }
      else {
        this.table.clear();
        this.table.rows.add(this.rolesData);
        this.table.draw();
      }

      this.roles = data.data.map((item) => {
        return {
          key: item.roleCd,
          value: item.roleCd
        }
      })
    });
  }

  private createTable(dataGrid: RolesInfo[]): boolean {
    this.table = this.jquery.$('#tableGridRoles').DataTable({
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
    this.jquery.$('#tableGridRoles tbody').on('click', 'tr', function () {
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
        console.log(_this.rowTable);
        let activoFg = _this.rowTable.activoFg == null ? 0 : _this.rowTable.activoFg
        _this.jquery.$('#estatuId').val(activoFg);
        _this.jquery.$('#estatuId').select2().trigger('change');
      }
    });
  }

  //Estatus del Rol
  public getEstatusInfo() {
    let response: Observable<Object> = this.configuracionesService.getEstatusInfo();
    response.subscribe((data2: any) => {

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
