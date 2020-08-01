import { Component, OnInit } from '@angular/core';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Leccion } from 'src/app/models/leccion';
import { CursoDetalle } from 'src/app/models/cursoDetalle';

@Component({
  selector: 'app-curso-participante',
  templateUrl: './curso-participante.component.html',
  styleUrls: ['./curso-participante.component.css']
})
export class CursoParticipanteComponent implements OnInit {
  cursoDetalle: CursoDetalle;
  lecciones: Leccion[];
  idParticipante: any;

  constructor(private router: Router, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.cursoDetalle = data['cursoDetalle'];
      this.lecciones = this.cursoDetalle.lecciones;
    });
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
  }

  onSelect(leccion: Leccion): void {
    this.router.navigate(['/leccion-participante', this.idParticipante, this.cursoDetalle.idEtapa, this.cursoDetalle.id, leccion.id]);
  }

}
