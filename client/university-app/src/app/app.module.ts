import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; 

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AngularMaterialModule} from './material/angular-material.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminAlumnosComponent } from './admin-alumnos/admin-alumnos.component';
import { AdminAsignaturasComponent } from './admin-asignaturas/admin-asignaturas.component';

import { AlumnosService } from './services/alumnos.service';
import { AsignaturasService } from './services/asignaturas.service';

@NgModule({
  declarations: [
    AppComponent,
    AdminAlumnosComponent,
    AdminAsignaturasComponent
  ],
  imports: [
    BrowserModule,
    AngularMaterialModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [AlumnosService, AsignaturasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
