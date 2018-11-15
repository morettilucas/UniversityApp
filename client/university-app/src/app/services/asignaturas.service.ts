import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {Observable} from 'rxjs';

import {Asignatura} from '../model/asignatura';

import {environment} from '../../environments/environment';
import {Curso} from '../model/curso';
import {Alumno} from '../model/alumno';
import {CicloLectivo} from '../model/cicloLectivo';
import {formatDate} from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AsignaturasService {

  constructor(private http: HttpClient) {
  }

  getAsignaturas(): Observable<Asignatura[]> {
    const url = `${environment.apiUrl}/asignaturas`;

    return this.http.get<Asignatura[]>(url);
  }

  getAlumnos(curso: Curso, cicloLectivo: CicloLectivo) {
    const url = `${environment.apiUrl}/asignaturas/alumnos?idAsignatura=${curso.IDAsignatura}&idCurso=${curso.IDCurso}&fechaDesde=${formatDate(cicloLectivo.FechaDesde, 'mediumDate', 'en-US')}&fechaHasta=${formatDate(cicloLectivo.FechaHasta, 'mediumDate', 'en-US')}`;

    return this.http.get<Alumno[]>(url);
  }
}
