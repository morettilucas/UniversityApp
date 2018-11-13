import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AltaEdicionAlumnoDialogComponent } from './alta-edicion-alumno-dialog.component';

describe('AltaEdicionAlumnoDialogComponent', () => {
  let component: AltaEdicionAlumnoDialogComponent;
  let fixture: ComponentFixture<AltaEdicionAlumnoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AltaEdicionAlumnoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AltaEdicionAlumnoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
