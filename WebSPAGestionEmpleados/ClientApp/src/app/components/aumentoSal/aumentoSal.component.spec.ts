import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AumentosComponent } from './aumentoSal.component';

describe('AumentosComponent', () => {
  let component: AumentosComponent;
  let fixture: ComponentFixture<AumentosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AumentosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AumentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
