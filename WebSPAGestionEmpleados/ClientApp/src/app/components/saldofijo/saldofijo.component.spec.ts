import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaldofijoComponent } from './saldofijo.component';

describe('SaldofijoComponent', () => {
  let component: SaldofijoComponent;
  let fixture: ComponentFixture<SaldofijoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaldofijoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaldofijoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
