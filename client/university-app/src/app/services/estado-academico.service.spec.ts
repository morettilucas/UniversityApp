import { TestBed } from '@angular/core/testing';

import { EstadoAcademicoService } from './estado-academico.service';

describe('EstadoAcademicoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EstadoAcademicoService = TestBed.get(EstadoAcademicoService);
    expect(service).toBeTruthy();
  });
});
