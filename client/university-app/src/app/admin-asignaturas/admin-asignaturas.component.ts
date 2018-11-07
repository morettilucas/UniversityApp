import { Component, OnInit, OnDestroy } from '@angular/core';

import {Subscription} from 'rxjs';

import {AsignaturasService} from '../services/asignaturas.service'
import {Asignatura} from '../model/asignatura';

@Component({
  selector: 'app-admin-asignaturas',
  templateUrl: './admin-asignaturas.component.html',
  styleUrls: ['./admin-asignaturas.component.scss']
})
export class AdminAsignaturasComponent implements OnInit, OnDestroy {

  constructor(private asignaturasService: AsignaturasService) { }

  displayedColumns: string[] = ['Nombre'];

  subscription = new Subscription();
  asignaturas: Asignatura[] = [];

  ngOnInit() {
    this.subscription.add(
      this.asignaturasService.getAsignaturas().subscribe(asignaturas => {
        this.asignaturas = asignaturas;
      })
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
