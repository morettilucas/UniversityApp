import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs'

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
}
