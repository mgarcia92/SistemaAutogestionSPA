import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-sidebar',
  templateUrl: './main-sidebar.component.html',
  styleUrls: ['./main-sidebar.component.css']
})
export class MainSidebarComponent implements OnInit {

  constructor() { }

  ngOnInit(){
    (window as any).$('body').layout('fix');
    (window as any).$(document).ready(() => {
      const trees: any =(window as any).$('[data-widget="tree"]');
      trees.tree();
    });
  }
}
