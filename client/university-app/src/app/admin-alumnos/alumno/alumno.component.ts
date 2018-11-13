import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { InscripcionesService } from '../../services/inscripciones.service';
import { AlumnosService } from '../../services/alumnos.service';

import { Curso } from '../../model/curso';
import { Alumno } from '../../model/alumno';

@Component({
  selector: 'app-alumno',
  templateUrl: './alumno.component.html',
  styleUrls: ['./alumno.component.scss']
})
export class AlumnoComponent implements OnInit {

  alumno: Alumno;

  constructor(
    private activatedRoute: ActivatedRoute,
    private alumnosService: AlumnosService,
    private inscripcionesService: InscripcionesService
  ) {
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      const id = +params['id'];
      this.alumnosService.getAlumno(id).subscribe(alumno => this.alumno = alumno);
    });
  }

  verAsignaturas() {
    confirm('asignaturas!');
  }

  solicitarInscripcion(curso: Curso) {
    this.inscripcionesService.inscripcion(this.alumno, curso)
      .subscribe(() => console.log('Listo !'));
  }
}
