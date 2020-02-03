import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import {MatButtonModule, MatIconModule} from '@angular/material';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlatpickrModule } from 'angularx-flatpickr';
import localeEs from '@angular/common/locales/es';
import { BsDatepickerModule, TimepickerModule } from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';

import { CursosComponent } from './actualizar-cursos/cursos.component';
import { RegistrarCursoComponent } from './actualizar-cursos/registrar-curso/registrar-curso.component';
import { EditarCursoComponent } from './actualizar-cursos/editar-curso/editar-curso.component';
import { EditarImagenComponent } from './actualizar-cursos/editar-imagen/editar-imagen.component';
import { ActualizarLeccionesComponent } from './actualizar-lecciones/actualizar-lecciones.component';
import { RegistrarLeccionComponent } from './actualizar-lecciones/registrar-leccion/registrar-leccion.component';
import { EditarLeccionComponent } from './actualizar-lecciones/editar-leccion/editar-leccion.component';
// tslint:disable-next-line:max-line-length
import { ActualizarLeccionMaterialComponent } from './actualizar-lecciones/actualizar-leccion-material/actualizar-leccion-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarLeccionMaterialComponent } from './actualizar-lecciones/actualizar-leccion-material/registrar-leccion-material/registrar-leccion-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarVideoMaterialComponent } from './actualizar-lecciones/actualizar-leccion-material/registrar-video-material/registrar-video-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarPresentacionMaterialComponent } from './actualizar-lecciones/actualizar-leccion-material/registrar-presentacion-material/registrar-presentacion-material.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { CursoImagenResolver } from 'src/app/resolvers/curso/curso-imagen.resolver';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { LeccionMaterialResolver } from 'src/app/resolvers/leccion/leccion-material.resolver';
import { LeccionMaterialesResolver } from 'src/app/resolvers/leccion/leccion-materiales.resolver';
import { LeccionResolver } from 'src/app/resolvers/leccion/leccion.resolver';
import { TipoContenidoResolver } from 'src/app/resolvers/tipocontenido/tipocontenido.resolver';
import { TipocontenidoService } from 'src/app/services/tipocontenido/tipocontenido.service';
import { RouterModule } from '@angular/router';

@NgModule({
   declarations: [
      CursosComponent,
      RegistrarCursoComponent,
      EditarCursoComponent,
      EditarImagenComponent,
      ActualizarLeccionesComponent,
      RegistrarLeccionComponent,
      EditarLeccionComponent,
      ActualizarLeccionMaterialComponent,
      RegistrarLeccionMaterialComponent,
      RegistrarVideoMaterialComponent,
      RegistrarPresentacionMaterialComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      DataTablesModule,
      MatButtonModule,
      MatIconModule,
      NgxSpinnerModule,
      BrowserAnimationsModule,
      FileUploadModule,
      FlatpickrModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TimepickerModule.forRoot(),
      NgbModule,
      RouterModule,
   ],
   providers: [
      CursosService,
      CursoImagenResolver,
      LeccionService,
      LeccionMaterialResolver,
      LeccionMaterialesResolver,
      LeccionResolver,
      TipoContenidoResolver,
      TipocontenidoService
   ]
})
export class SherpaModule { }
