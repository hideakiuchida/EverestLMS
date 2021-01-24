import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Etapa } from 'src/app/models/etapa';
import { Curso } from 'src/app/models/curso';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { CursoToRegister } from 'src/app/models/cursoToRegister';

@Component({
  selector: 'app-editar-leccion',
  templateUrl: './editar-leccion.component.html',
  styleUrls: ['./editar-leccion.component.css']
})
export class EditarLeccionComponent implements OnInit {
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  etapas: Etapa[];
  cursos: Curso[];
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  selectedEtapaId: any;
  selectedCursoId: any;
  leccionForm: FormGroup;
  leccionToRegiter: LeccionToRegister;
  curso: CursoToRegister;
  idLeccion: any;
  isEditForm: boolean;

  constructor(private formBuilder: FormBuilder, private leccionService: LeccionService, private cursoService: CursosService,
              private etapaService: EtapaService, private route: ActivatedRoute,
              private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.niveles = data.niveles;
      this.lineaCarreras = data.lineaCarreras;
      this.curso = data.curso;
      this.leccionToRegiter = data.leccion;
    });
    this.initParameters();
    if (this.isEditForm) {
      this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId, false);
    }
    this.createLeccionForm();
  }

  initParameters() {
    this.selectedLineaCarreraId = this.curso?.idLineaCarrera;
    this.selectedNivelId = this.curso?.idNivel;
    this.selectedEtapaId = this.leccionToRegiter?.idEtapa;
    this.selectedCursoId = this.leccionToRegiter?.idCurso;
    this.idLeccion = this.route.snapshot.params.idLeccion;
    this.isEditForm = this.idLeccion !== undefined && this.idLeccion !== '';
  }

  createLeccionForm() {
    this.leccionForm = this.formBuilder.group({
      id: this.leccionToRegiter?.id,
      nombre: [this.leccionToRegiter?.nombre, [Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      descripcion: [this.leccionToRegiter?.descripcion, [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
      idNivel: [this.selectedNivelId, [Validators.required]],
      idLineaCarrera: [this.selectedLineaCarreraId, [Validators.required]],
      idEtapa: [this.selectedEtapaId, [Validators.required]],
      idCurso: [this.selectedCursoId, [Validators.required]],
      puntaje: [this.leccionToRegiter?.puntaje, [Validators.required]]
    });
  }

  lineaCarreraSelected(event) {
    this.selectedLineaCarreraId = event.target.value;
    if (this.selectedLineaCarreraId != null && this.selectedNivelId != null) {
      this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId, true);
    }
  }

  nivelSelected(event) {
    this.selectedNivelId = event.target.value;
    if (this.selectedLineaCarreraId != null && this.selectedNivelId != null) {
      this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId, true);
    }
  }

  etapaSelected(event) {
    this.selectedEtapaId = event.target.value;
    if (this.selectedLineaCarreraId != null && this.selectedNivelId != null && this.selectedEtapaId != null) {
      this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, true);
    }
  }

  loadEtapas(idLineaCarrera, idNivel, selected) {
    this.etapaService.getEtapas(idLineaCarrera, idNivel, null).subscribe((etapas: Etapa[]) => {
      if (etapas.length > 0) {
        this.etapas = etapas;
        if (selected) {
          this.selectedEtapaId = etapas[0].id;
          this.leccionForm.controls.idEtapa.setValue(this.selectedEtapaId);
        }
        this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, selected);
      } else {
        this.alertify.warning('No existen etapas en base a estos criterios seleccionados');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  loadCursos(idEtapa, idLineaCarrera, idNivel, selected) {
    this.cursoService.getCursos(idEtapa, idLineaCarrera, idNivel, null).subscribe((cursos: Curso[]) => {
      if (cursos.length > 0) {
        this.cursos = cursos;
        if (selected) {
          this.selectedCursoId = this.cursos[0].id;
          this.leccionForm.controls.idCurso.setValue(this.selectedCursoId);
        }
      } else {
        this.alertify.warning('No existen cursos en base a los criterios seleccionados');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  submitLeccion() {
    if (this.leccionForm.valid) {
      this.leccionToRegiter = Object.assign({}, this.leccionForm.value);
      this.leccionToRegiter.idCurso = +this.leccionToRegiter.idCurso;
      this.leccionToRegiter.idEtapa = +this.leccionToRegiter.idEtapa;
      if (!this.isEditForm) {
        this.createLeccion();
      } else {
       this.editarLeccion();
      }
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }

  createLeccion() {
    this.leccionService.createLeccion(this.leccionToRegiter.idEtapa, this.leccionToRegiter.idCurso, this.leccionToRegiter)
    .subscribe((idLeccion: number) => {
      this.idLeccion = idLeccion;
      this.alertify.success('Se registró existosamente.');
    }, error => {
      this.alertify.error(error.message);
    }, () => {
       // tslint:disable-next-line:no-debugger
      debugger;
      this.router.navigate(['actualizar-contenido', this.leccionToRegiter.idEtapa, this.leccionToRegiter.idCurso, this.idLeccion]);
    });
  }

  editarLeccion() {
    this.leccionService.editLeccion(this.leccionToRegiter.idEtapa, this.leccionToRegiter.idCurso,
      this.leccionToRegiter.id, this.leccionToRegiter)
    .subscribe(() => {
      this.alertify.success('Se actualizó existosamente.');
    }, error => {
      this.alertify.error(error.message);
    }, () => {
      this.router.navigate(['actualizar-contenido', this.leccionToRegiter.idEtapa,
      this.leccionToRegiter.idCurso, this.leccionToRegiter.id]);
    });
  }
}
