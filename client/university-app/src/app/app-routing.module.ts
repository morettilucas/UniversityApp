import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AppComponent} from './app.component';
import {AdminAlumnosComponent } from './admin-alumnos/admin-alumnos.component';
import {AdminAsignaturasComponent} from './admin-asignaturas/admin-asignaturas.component';

const routes: Routes = [
  { path: '', redirectTo: '/alumnos', pathMatch: 'full' },
  { path: 'alumnos', component: AdminAlumnosComponent},
  { path: 'asignaturas', component: AdminAsignaturasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
