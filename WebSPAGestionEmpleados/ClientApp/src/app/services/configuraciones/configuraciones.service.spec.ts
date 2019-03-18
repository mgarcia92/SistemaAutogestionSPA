import { TestBed, inject } from '@angular/core/testing';

import { ConfiguracionesService } from './configuraciones.service';

describe('ConfiguracionesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ConfiguracionesService]
    });
  });

  it('should be created', inject([ConfiguracionesService], (service: ConfiguracionesService) => {
    expect(service).toBeTruthy();
  }));
});
