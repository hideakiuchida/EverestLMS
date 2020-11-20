import { Component, OnInit } from '@angular/core';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Etapa } from 'src/app/models/etapa';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
import { Curso } from 'src/app/models/curso';
import { LeccionService } from 'src/app/services/leccion/leccion.service';

@Component({
  selector: 'app-registrar-leccion',
  templateUrl: './registrar-leccion.component.html',
  styleUrls: ['./registrar-leccion.component.css']
})
export class RegistrarLeccionComponent implements OnInit {
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  etapas: Etapa[];
  cursos: Curso[];
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  selectedEtapaId: any;
  leccionForm: FormGroup;
  leccionToRegiter: LeccionToRegister;
  idLeccion: number;

  constructor(private formBuilder: FormBuilder, private leccionService: LeccionService, private cursoService: CursosService,
              private etapaService: EtapaService, private route: ActivatedRoute,
              private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.niveles = data.niveles;
      this.lineaCarreras = data.lineaCarreras;
    });
    this.createLeccionForm();
  }

  createLeccionForm() {
    this.leccionForm = this.formBuilder.group({
      nombre: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      descripcion: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
      idNivel: ['', [Validators.required]],
      idLineaCarrera: ['', [Validators.required]],
      idEtapa: ['', [Validators.required]],
      idCurso: ['', [Validators.required]],
      puntaje: ['', [Validators.required]]
    });
  }

  lineaCarreraSelected(event) {
    this.selectedLineaCarreraId = event.target.value;
    if (this.selectedLineaCarreraId != null && this.selectedNivelId != null) {
      this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
    }
  }

  nivelSelected(event) {
    this.selectedNivelId = event.target.value;
    if (this.selectedLineaCarreraId != null && this.selectedNivelId != null) {
      this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
    }
  }

  etapaSelected(event) {
    this.selectedEtapaId = event.target.value;
    if (this.selectedLineaCarreraId != null && this.selectedNivelId != null && this.selectedEtapaId != null) {
      this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId);
    }
  }

  loadEtapas(idLineaCarrera, idNivel) {
    this.etapaService.getEtapas(idLineaCarrera, idNivel, null).subscribe((etapas: Etapa[]) => {
      if (etapas.length > 0) {
        this.etapas = etapas;
        this.selectedEtapaId = etapas[0].id;
        this.leccionForm.controls.idEtapa.setValue(this.selectedEtapaId);
        this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId);
      } else {
        this.alertify.warning('No existen etapas en base a estos criterios seleccionados');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  loadCursos(idEtapa, idLineaCarrera, idNivel) {
    this.cursoService.getCursos(idEtapa, idLineaCarrera, idNivel, null).subscribe((cursos: Curso[]) => {
      if (cursos.length > 0) {
        this.cursos = cursos;
        this.leccionForm.controls.idCurso.setValue(this.cursos[0].id);
      } else {
        this.alertify.warning('No existen cursos en base a los criterios seleccionados');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  registrarLeccion() {
    if (this.leccionForm.valid) {
      this.leccionToRegiter = Object.assign({}, this.leccionForm.value);
      this.leccionToRegiter.idCurso = +this.leccionToRegiter.idCurso;
      this.leccionToRegiter.idEtapa = +this.leccionToRegiter.idEtapa;
      this.leccionService.createLeccion(this.leccionToRegiter.idEtapa, this.leccionToRegiter.idCurso, this.leccionToRegiter)
      .subscribe((idLeccion: number) => {
        this.idLeccion = idLeccion;
        this.alertify.success('Se registró existosamente.');
      }, error => {
        this.alertify.error(error.message);
      }, () => {
        this.router.navigate(['actualizar-contenido', this.leccionToRegiter.idEtapa, this.leccionToRegiter.idCurso, this.idLeccion, '']);
      });
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }
}
