import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAsignaturasComponent } from './admin-asignaturas.component';

describe('AdminAsignaturasComponent', () => {
  let component: AdminAsignaturasComponent;
  let fixture: ComponentFixture<AdminAsignaturasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminAsignaturasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAsignaturasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
