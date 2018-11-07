import { Component, OnInit, OnDestroy } from '@angular/core';

import {Subscription} from 'rxjs';

import {AlumnosService} from '../services/alumnos.service'
import {Alumno} from '../model/alumno';

@Component({
  selector: 'app-admin-alumnos',
  templateUrl: './admin-alumnos.component.html',
  styleUrls: ['./admin-alumnos.component.scss']
})
export class AdminAlumnosComponent implements OnInit, OnDestroy {

  constructor(private alumnosService: AlumnosService) { }

  displayedColumns: string[] = ['Nombre', 'Legajo'];

  subscription = new Subscription();
  alumnos: Alumno[] = [];

  ngOnInit() {
    this.subscription.add(
      this.alumnosService.getAlumnos().subscribe(alumnos => {
        this.alumnos = alumnos;
        console.log(this.alumnos)
      })
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
