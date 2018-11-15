import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {EstadoAcademico} from '../model/estadoAcademico';

@Injectable({
  providedIn: 'root'
})
export class EstadoAcademicoService {

  constructor(private http: HttpClient) {
  }

  estadoAcademicoPorAlumno(id: number): Observable<EstadoAcademico> {
    const url = `${environment.apiUrl}/estadoAcademico?idAlumno=${id}`;

    return this.http.get<EstadoAcademico>(url);
  }
}
