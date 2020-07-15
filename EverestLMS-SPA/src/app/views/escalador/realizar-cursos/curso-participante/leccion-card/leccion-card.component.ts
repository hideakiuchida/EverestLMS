import { Component, OnInit, Input } from '@angular/core';
import { Leccion } from 'src/app/models/leccion';

@Component({
  selector: 'app-leccion-card',
  templateUrl: './leccion-card.component.html',
  styleUrls: ['./leccion-card.component.css']
})
export class LeccionCardComponent implements OnInit {

  @Input() leccion: Leccion;

  constructor() { }

  ngOnInit() {
  }
}
