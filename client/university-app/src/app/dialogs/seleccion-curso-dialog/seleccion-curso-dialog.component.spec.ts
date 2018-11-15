import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeleccionCursoDialogComponent } from './seleccion-curso-dialog.component';

describe('SeleccionCursoDialogComponent', () => {
  let component: SeleccionCursoDialogComponent;
  let fixture: ComponentFixture<SeleccionCursoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeleccionCursoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeleccionCursoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
