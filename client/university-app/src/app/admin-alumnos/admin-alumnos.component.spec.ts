import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAlumnosComponent } from './admin-alumnos.component';

describe('AdminAlumnosComponent', () => {
  let component: AdminAlumnosComponent;
  let fixture: ComponentFixture<AdminAlumnosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminAlumnosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAlumnosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
