import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  idParticipante: any = 2423;

  constructor() { }

  ngOnInit() {
  }

  login() {
  }

}
