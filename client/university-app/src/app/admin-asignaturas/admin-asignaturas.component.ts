import {state, trigger, animate, style, transition} from '@angular/animations';
import {Component, OnInit, OnDestroy, Input} from '@angular/core';

import {Subscription} from 'rxjs';

import {AsignaturasService} from '../services/asignaturas.service';
import {Asignatura} from '../model/asignatura';
import {Curso} from '../model/curso';
import {CicloLectivo} from '../model/cicloLectivo';
import {MatDialog} from '@angular/material';
import {SeleccionCursoDialogComponent} from '../dialogs/seleccion-curso-dialog/seleccion-curso-dialog.component';
import {ListaAlumnosDialogComponent} from '../dialogs/lista-alumnos-dialog/lista-alumnos-dialog.component';

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

  constructor(private asignaturasService: AsignaturasService,
              private dialog: MatDialog) {
  }

  @Input('habilitarInscripcion') habilitarInscrpcion: boolean;

  subscription = new Subscription();
  asignaturas: Asignatura[] = [];

  cicloLectivoActual: CicloLectivo;

  ngOnInit() {
    this.cicloLectivoActual = new CicloLectivo(new Date(2018, 1, 1), new Date(2018, 12, 31));
    this.subscription.add(
      this.asignaturasService.getAsignaturas().subscribe(asignaturas => {
        this.asignaturas = asignaturas;
      })
    );
  }

  verAlumnos(curso: Curso) {
    this.asignaturasService.getAlumnos(curso, this.cicloLectivoActual).subscribe(alumnos => {
      const dialogRef = this.dialog.open(ListaAlumnosDialogComponent);
      dialogRef.componentInstance.alumnos = alumnos;

      return dialogRef.afterClosed();
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
