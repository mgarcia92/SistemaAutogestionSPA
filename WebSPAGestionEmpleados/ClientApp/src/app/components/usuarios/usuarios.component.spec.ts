import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { usuarioComponent } from './usuarios.component';

describe('usuarioComponent', () => {
  let component: usuarioComponent;
  let fixture: ComponentFixture<usuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [usuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(usuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
