import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs'

import { Asignatura } from '../model/asignatura';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AsignaturasService {

  constructor(private http: HttpClient) {}

  getAsignaturas(): Observable<Asignatura[]> {
    const url = `${environment.apiUrl}/asignaturas`;

    return this.http.get<Asignatura[]>(url);
  }
}
