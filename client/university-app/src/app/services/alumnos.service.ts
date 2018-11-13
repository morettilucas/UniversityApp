import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

import { Observable } from 'rxjs';

import { Alumno } from '../model/alumno';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AlumnosService {

  constructor(private http: HttpClient) {}

  getAlumnos(): Observable<Alumno[]> {
    const url = `${environment.apiUrl}/alumnos`;

    return this.http.get<Alumno[]>(url);
  }

  getAlumno(id: number): Observable<Alumno> {
    const url = `${environment.apiUrl}/alumnos/${id}`;

    return this.http.get<Alumno>(url);
  }

  nuevoAlumno(alumno: Alumno): Observable<any> {
    const url = `${environment.apiUrl}/alumnos`;

    return this.http.post<Alumno>(url, alumno);
  }

  actualizarAlumno(alumno: Alumno): Observable<any> {
    const url = `${environment.apiUrl}/alumnos/${alumno.IDAlumno}`;

    return this.http.put<Alumno>(url, alumno);
  }

  eliminarAlumno(alumno: Alumno): Observable<any> {
    const url = `${environment.apiUrl}/alumnos/${alumno.IDAlumno}`;

    return this.http.delete(url);
  }
}
