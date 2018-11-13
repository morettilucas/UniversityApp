import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { SolicitudInscripcion } from '../model/solicitudInscripcion';
import { Alumno } from '../model/alumno';
import { Curso } from '../model/curso';

@Injectable({
  providedIn: 'root'
})
export class InscripcionesService {

  constructor(private http: HttpClient) {}

  inscripcion(alumno: Alumno, curso: Curso) {
    const url = `${environment.apiUrl}/inscripciones`;

    const solicitud = new SolicitudInscripcion();
    solicitud.AlumnoId = alumno.IDAlumno;
    solicitud.CursoId = curso.IDCurso;
    solicitud.AsignaturaId = curso.IDAsignatura;

    return this.http.post<SolicitudInscripcion>(url, solicitud);
  }
}
