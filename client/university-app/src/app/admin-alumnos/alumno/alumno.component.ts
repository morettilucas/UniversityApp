import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';

import {InscripcionesService} from '../../services/inscripciones.service';
import {AlumnosService} from '../../services/alumnos.service';

import {Curso} from '../../model/curso';
import {Alumno} from '../../model/alumno';
import {EstadoAcademico} from '../../model/estadoAcademico';
import {EstadoAcademicoService} from '../../services/estado-academico.service';
import {Asignatura} from '../../model/asignatura';
import {MatDialog} from '@angular/material';
import {AltaEdicionAlumnoDialogComponent} from '../../dialogs/alta-edicion-alumno-dialog/alta-edicion-alumno-dialog.component';
import {of} from 'rxjs';
import {flatMap, tap} from 'rxjs/operators';
import {SeleccionCursoDialogComponent} from '../../dialogs/seleccion-curso-dialog/seleccion-curso-dialog.component';

@Component({
  selector: 'app-alumno',
  templateUrl: './alumno.component.html',
  styleUrls: ['./alumno.component.scss']
})
export class AlumnoComponent implements OnInit {

  alumno: Alumno;
  estadoAcademico: EstadoAcademico;

  constructor(
    private activatedRoute: ActivatedRoute,
    private alumnosService: AlumnosService,
    private inscripcionesService: InscripcionesService,
    private estadoAcademicoService: EstadoAcademicoService,
    private dialog: MatDialog
  ) {
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      const id = +params['id'];
      this.alumnosService.getAlumno(id).subscribe(alumno => {
        this.alumno = alumno;
        this.obtenerEstadoAcademico();
      });
    });
  }

  private obtenerEstadoAcademico() {
    this.estadoAcademicoService.estadoAcademicoPorAlumno(this.alumno.IDAlumno).subscribe(estado => this.estadoAcademico = estado);
  }

  solicitarInscripcion(asignatura: Asignatura) {
    const dialogRef = this.dialog.open(SeleccionCursoDialogComponent);
    dialogRef.componentInstance.cursos = asignatura.Cursos;
    
    dialogRef.afterClosed().pipe(
      flatMap((curso: Curso) => {
        if (!curso) {
          return of({});
        }
        return this.inscripcionesService.inscripcion(this.alumno, curso);
      }),
      tap(() => this.obtenerEstadoAcademico())
    ).subscribe();
  }
}
