import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from '@angular/material';
import {Alumno} from '../../model/alumno';
import {Router} from '@angular/router';

@Component({
  selector: 'app-lista-alumnos-dialog',
  templateUrl: './lista-alumnos-dialog.component.html',
  styleUrls: ['./lista-alumnos-dialog.component.scss']
})
export class ListaAlumnosDialogComponent implements OnInit {

  alumnos: Alumno[];

  constructor(public dialogRef: MatDialogRef<ListaAlumnosDialogComponent>,
              private router: Router) {
  }

  ngOnInit() {
  }

  ver(alumno: Alumno) {
    this.dialogRef.close();
    this.router.navigate([`/alumnos`, alumno.IDAlumno]);
  }

  listo() {
    this.dialogRef.close();
  }
}
