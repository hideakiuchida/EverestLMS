import { Component, OnInit, SecurityContext } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { LeccionEscalador } from 'src/app/models/leccionEscalador';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-leccion-participante',
  templateUrl: './leccion-participante.component.html',
  styleUrls: ['./leccion-participante.component.css']
})
export class LeccionParticipanteComponent implements OnInit {
  idParticipante: any;
  idCurso: any;
  idLeccion: any;
  leccionEscalador: any;
  idEtapa: any;
  htmlContent: any;

  constructor(private router: Router, protected sanitizer: DomSanitizer, private route: ActivatedRoute, 
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.leccionEscalador = data.leccionEscalador;
      this.htmlContent = this.sanitizer.bypassSecurityTrustHtml(this.leccionEscalador.contenidoHTML);
      this.htmlContent = this.sanitizer.sanitize(SecurityContext.HTML,this.htmlContent);
      console.log(this.leccionEscalador);
      
    });
    
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
  }

}
