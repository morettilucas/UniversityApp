import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Alumno } from '../../model/alumno';

@Component({
  selector: 'app-alta-edicion-alumno-dialog',
  templateUrl: './alta-edicion-alumno-dialog.component.html',
  styleUrls: ['./alta-edicion-alumno-dialog.component.scss']
})
export class AltaEdicionAlumnoDialogComponent implements OnInit {

  alumno: Alumno;
  esEdicion = false;

  minDate = new Date(1960, 0, 0);
  maxDate = new Date();

  constructor(public dialogRef: MatDialogRef<AltaEdicionAlumnoDialogComponent>) {}

  ngOnInit() {
    this.esEdicion = this.alumno != null;
    if (this.alumno == null) this.alumno = new Alumno();
  }

  listo() {
    this.dialogRef.close(this.alumno);
  }

  cancelar() {
    this.dialogRef.close();
  }
}
