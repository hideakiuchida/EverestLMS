import { NgModule } from '@angular/core';
import localeEs from '@angular/common/locales/es';
import { registerLocaleData, DatePipe } from '@angular/common';

import { AppComponent } from './app.component';

import { AdminModule } from './views/admin/admin.module';
import { SherpaModule } from './views/sherpa/sherpa.module';
import { EscaladorModule } from './views/escalador/escalador.module';
import { SharedModule } from './views/shared/shared.module';

registerLocaleData(localeEs);

@NgModule({
   declarations: [
      AppComponent
   ],
   imports: [
      SharedModule,
      AdminModule,
      SherpaModule,
      EscaladorModule
   ],
   providers: [
      DatePipe
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
