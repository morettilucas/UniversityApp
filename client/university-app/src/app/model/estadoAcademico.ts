import {Asignatura} from './asignatura';

export class EstadoAcademico {
  IDAlumno: number;
  AsignaturasPorCursar: Asignatura[];
  AsignaturasInscripto: Asignatura[];
  AsignaturasNoRegular: Asignatura[];
}
