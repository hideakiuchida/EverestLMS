import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-actualizar-contenido',
  templateUrl: './actualizar-contenido.component.html',
  styleUrls: ['./actualizar-contenido.component.css']
})
export class ActualizarContenidoComponent implements OnInit {
  modalRef: BsModalRef;
  baseUrl = environment.apiUrl;


  idEtapa: any;
  idCurso: any;
  idLeccion: any;

  constructor(private route: ActivatedRoute, private router: Router, private modalService: BsModalService) { }

  ngOnInit() {
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
  }
}
