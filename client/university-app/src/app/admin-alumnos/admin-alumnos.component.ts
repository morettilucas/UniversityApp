import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';

import { Subscription, Observable, of } from 'rxjs';
import { flatMap, tap } from 'rxjs/operators';

import { AlumnosService } from '../services/alumnos.service';
import { Alumno } from '../model/alumno';
import { AltaEdicionAlumnoDialogComponent } from
  '../dialogs/alta-edicion-alumno-dialog/alta-edicion-alumno-dialog.component';

@Component({
  selector: 'app-admin-alumnos',
  templateUrl: './admin-alumnos.component.html',
  styleUrls: ['./admin-alumnos.component.scss']
})
export class AdminAlumnosComponent implements OnInit, OnDestroy {

  constructor(private alumnosService: AlumnosService,
    private router: Router,
    private dialog: MatDialog) {
  }

  displayedColumns: string[] = ['Nombre', 'Legajo', 'Edad', 'FechaNacimiento', 'ver', 'editar', 'eliminar'];

  subscription: Subscription;
  alumnos: Alumno[] = [];

  ngOnInit() {
    this.obtenerAlumnos();
  }

  agregarAlumno() {
    const dialogRef = this.dialog.open(AltaEdicionAlumnoDialogComponent);

    dialogRef.afterClosed().pipe(
        flatMap((alumno: Alumno) => {
          if (!alumno) {
            return of({});
          }
          return this.alumnosService.nuevoAlumno(alumno);
        }),
        tap(() => this.obtenerAlumnos()))
      .subscribe();
  };

  ver(alumno: Alumno) {
    this.router.navigate([`/alumnos`, alumno.IDAlumno]);
  }

  editar(alumno: Alumno) {
    const copiaAlumno = JSON.parse(JSON.stringify(alumno));

    const dialogRef = this.dialog.open(AltaEdicionAlumnoDialogComponent);
    dialogRef.componentInstance.alumno = copiaAlumno;

    dialogRef.afterClosed().pipe(
        flatMap((alumno: Alumno) => {
          if (!alumno) {
            return of({});
          }
          return this.alumnosService.actualizarAlumno(copiaAlumno);
        }),
        tap(() => this.obtenerAlumnos()))
      .subscribe();
  }

  eliminar(alumno: Alumno) {
    this.alumnosService.eliminarAlumno(alumno)
      .subscribe(() => this.obtenerAlumnos());
  }

  obtenerAlumnos() {
    if (this.subscription != null) this.subscription.unsubscribe();

    this.subscription = this.alumnosService.getAlumnos().subscribe(alumnos => {
      this.alumnos = alumnos;
      console.log(this.alumnos);
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
