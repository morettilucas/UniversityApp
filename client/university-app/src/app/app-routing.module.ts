import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAlumnosComponent } from './admin-alumnos/admin-alumnos.component';
import { AdminAsignaturasComponent } from './admin-asignaturas/admin-asignaturas.component';
import { AlumnoComponent } from './admin-alumnos/alumno/alumno.component';

const routes: Routes = [
  { path: '', redirectTo: '/alumnos', pathMatch: 'full' },
  { path: 'alumnos', component: AdminAlumnosComponent },
  { path: 'alumnos/:id', component: AlumnoComponent },
  { path: 'asignaturas', component: AdminAsignaturasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
