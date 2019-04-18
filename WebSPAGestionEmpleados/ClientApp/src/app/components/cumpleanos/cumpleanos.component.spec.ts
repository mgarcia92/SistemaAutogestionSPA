import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CumpleanosComponent } from './cumpleanos.component';

describe('CumpleanosComponent', () => {
  let component: CumpleanosComponent;
  let fixture: ComponentFixture<CumpleanosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CumpleanosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CumpleanosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
