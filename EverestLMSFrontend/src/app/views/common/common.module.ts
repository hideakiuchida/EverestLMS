import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';

@NgModule({
   declarations: [
      NavComponent,
      HomeComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule,
      FormsModule
   ],
   providers: [
   ]
})
export class CommonModule { }
