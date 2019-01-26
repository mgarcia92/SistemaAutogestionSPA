import { TestBed, inject } from '@angular/core/testing';

import { EmpresaServiceService } from './empresa-service.service';

describe('EmpresaServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EmpresaServiceService]
    });
  });

  it('should be created', inject([EmpresaServiceService], (service: EmpresaServiceService) => {
    expect(service).toBeTruthy();
  }));
});
