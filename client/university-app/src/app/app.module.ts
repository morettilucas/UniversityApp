import { BrowserModule } from '@angular/platform-browser';
import {LOCALE_ID, NgModule} from '@angular/core';
import { FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AngularMaterialModule} from './material/angular-material.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminAlumnosComponent } from './admin-alumnos/admin-alumnos.component';
import { AdminAsignaturasComponent } from './admin-asignaturas/admin-asignaturas.component';

import { AlumnosService } from './services/alumnos.service';
import { AsignaturasService } from './services/asignaturas.service';
import { AltaEdicionAlumnoDialogComponent } from './dialogs/alta-edicion-alumno-dialog/alta-edicion-alumno-dialog.component';
import { AlumnoComponent } from './admin-alumnos/alumno/alumno.component';
import { SeleccionCursoDialogComponent } from './dialogs/seleccion-curso-dialog/seleccion-curso-dialog.component';
import { ListaAlumnosDialogComponent } from './dialogs/lista-alumnos-dialog/lista-alumnos-dialog.component';

import { registerLocaleData } from '@angular/common';
import localeEsAr from '@angular/common/locales/es-AR';
import localeEsArExtra from '@angular/common/locales/extra/es-AR';

registerLocaleData(localeEsAr, localeEsArExtra);

@NgModule({
  declarations: [
    AppComponent,
    AdminAlumnosComponent,
    AdminAsignaturasComponent,
    AltaEdicionAlumnoDialogComponent,
    AlumnoComponent,
    SeleccionCursoDialogComponent,
    ListaAlumnosDialogComponent
  ],
  imports: [
    BrowserModule,
    AngularMaterialModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [AlumnosService, AsignaturasService, { provide: LOCALE_ID, useValue: 'es-AR' }],
  bootstrap: [AppComponent],
  entryComponents: [AltaEdicionAlumnoDialogComponent, SeleccionCursoDialogComponent, ListaAlumnosDialogComponent]
})
export class AppModule { }
