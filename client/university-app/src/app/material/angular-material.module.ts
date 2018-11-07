import { NgModule } from '@angular/core';
import {
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatIconModule,
    MatTableModule,
    MatCardModule
  }
  from '@angular/material';

const angularModules = [
  MatButtonModule,
  MatCheckboxModule,
  MatIconModule,
  MatToolbarModule,
  MatTableModule,
  MatCardModule
];

@NgModule({
  imports: [angularModules],
  exports: [angularModules],
})
export class AngularMaterialModule {
}
