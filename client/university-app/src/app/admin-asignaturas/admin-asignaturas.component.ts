import { state, trigger, animate, style, transition} from '@angular/animations';
import { Component, OnInit, OnDestroy, Input, Output, EventEmitter } from '@angular/core';

import {Subscription} from 'rxjs';

import {AsignaturasService} from '../services/asignaturas.service'
import {Asignatura} from '../model/asignatura';
import { Curso } from '../model/curso';

@Component({
  selector: 'app-admin-asignaturas',
  templateUrl: './admin-asignaturas.component.html',
  styleUrls: ['./admin-asignaturas.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ])]
})
export class AdminAsignaturasComponent implements OnInit, OnDestroy {

  constructor(private asignaturasService: AsignaturasService) { }

  @Input('habilitarInscripcion') habilitarInscrpcion: boolean;
  @Output('inscribir') inscribir = new EventEmitter<Curso>();

  columnsToDisplay: string[] = ['Nombre'];
  displayedColumnsCurso: string[] = ['Nombre'];
  
  subscription = new Subscription();
  asignaturas: Asignatura[] = [];

  ngOnInit() {
    this.subscription.add(
      this.asignaturasService.getAsignaturas().subscribe(asignaturas => {
        this.asignaturas = asignaturas;
      })
    );
  }

  inscribirCurso(curso: Curso) {
    this.inscribir.emit(curso);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
