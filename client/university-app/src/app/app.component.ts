import {Component} from '@angular/core';
import {CicloLectivo} from './model/cicloLectivo';
import {initNgModule} from '@angular/core/src/view/ng_module';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'University App';
  inicio = new Date(2018, 0, 1);
  fin = new Date(2018, 11 , 31);

  cicloLectivo = new CicloLectivo(this.inicio, this.fin);
}
