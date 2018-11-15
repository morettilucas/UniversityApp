import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialogRef, MatListOption, MatSelectionList} from '@angular/material';
import {Curso} from '../../model/curso';
import {SelectionModel} from '@angular/cdk/collections';

@Component({
  selector: 'app-seleccion-curso-dialog',
  templateUrl: './seleccion-curso-dialog.component.html',
  styleUrls: ['./seleccion-curso-dialog.component.scss']
})
export class SeleccionCursoDialogComponent implements OnInit {

  cursoSeleccionado: Curso;
  cursos: Curso[];

  selectedOptions: Curso[];

  @ViewChild(MatSelectionList) selectionList: MatSelectionList;

  constructor(public dialogRef: MatDialogRef<SeleccionCursoDialogComponent>) {
  }

  ngOnInit() {
    this.selectionList.selectedOptions = new SelectionModel<MatListOption>(false);
  }

  onSelectionChange(selection) {
   // this.selectedOptions = [];
   // this.selectedOptions.push(selection);
  }

  listo() {
    this.cursoSeleccionado = this.selectedOptions[0];
    console.log(this.cursoSeleccionado);

    this.dialogRef.close(this.cursoSeleccionado);
  }
}
