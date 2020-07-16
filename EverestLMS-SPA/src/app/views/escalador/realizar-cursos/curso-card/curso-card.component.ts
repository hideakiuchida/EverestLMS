import { Component, OnInit, Input } from '@angular/core';
import { Curso } from 'src/app/models/curso';

@Component({
  selector: 'app-curso-card',
  templateUrl: './curso-card.component.html',
  styleUrls: ['./curso-card.component.css']
})
export class CursoCardComponent implements OnInit {

  @Input() curso: Curso;
  @Input() idParticipante: any;
  @Input() isCursoDetalle: boolean;

  constructor() { }

  ngOnInit() {
  }

}
