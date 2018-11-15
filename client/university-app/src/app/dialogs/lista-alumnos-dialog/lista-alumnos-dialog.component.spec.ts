import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAlumnosDialogComponent } from './lista-alumnos-dialog.component';

describe('ListaAlumnosDialogComponent', () => {
  let component: ListaAlumnosDialogComponent;
  let fixture: ComponentFixture<ListaAlumnosDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaAlumnosDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAlumnosDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
