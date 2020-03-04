import { Component, OnInit } from '@angular/core';
import { Etapa } from 'src/app/models/etapa';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Dificultad } from 'src/app/models/dificultad';
import { Idioma } from 'src/app/models/idioma';
import { CursoToRegister } from 'src/app/models/cursoToRegister';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-editar-curso',
  templateUrl: './editar-curso.component.html',
  styleUrls: ['./editar-curso.component.css']
})
export class EditarCursoComponent implements OnInit {
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  etapas: Etapa[];
  dificultades: Dificultad[];
  idiomas: Idioma[];
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  cursoForm: FormGroup;
  cursoToRegiter: CursoToRegister;

  constructor(private formBuilder: FormBuilder, private cursoService: CursosService, private etapaService: EtapaService,
              private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.niveles = data.niveles;
      this.lineaCarreras = data.lineaCarreras;
      this.idiomas = data.idiomas;
      this.dificultades = data.dificultades;
      this.cursoToRegiter = data.curso;
    });
    this.selectedLineaCarreraId = this.cursoToRegiter.idLineaCarrera;
    this.selectedNivelId = this.cursoToRegiter.idNivel;
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
    this.createCursonForm();
  }

  createCursonForm() {
    this.cursoForm = this.formBuilder.group({
      id: [this.cursoToRegiter.id, [Validators.required]],
      nombre: [this.cursoToRegiter.nombre, [Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      descripcion: [this.cursoToRegiter.descripcion, [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
      idNivel: [this.cursoToRegiter.idNivel, [Validators.required]],
      idLineaCarrera: [this.cursoToRegiter.idLineaCarrera, [Validators.required]],
      idEtapa: [this.cursoToRegiter.idEtapa, [Validators.required]],
      idDificultad: [this.cursoToRegiter.idDificultad, [Validators.required]],
      idIdioma: [this.cursoToRegiter.idIdioma, [Validators.required]],
      puntaje: [this.cursoToRegiter.puntaje, [Validators.required]],
      autor: [this.cursoToRegiter.autor]
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

  loadEtapas(idLineaCarrera, idNivel) {
    this.etapaService.getEtapas(idLineaCarrera, idNivel, null).subscribe((etapas: Etapa[]) => {
       this.etapas = etapas;
    }, error => {
      this.alertify.error(error);
    });
  }

  editarCurso() {
    if (this.cursoForm.valid) {
      this.cursoToRegiter = Object.assign({}, this.cursoForm.value);
      this.cursoToRegiter.imagen = 'Imagen 1';
      this.cursoService.editCurso(this.cursoToRegiter.idEtapa, this.cursoToRegiter.id, this.cursoToRegiter).subscribe(() => {
        this.alertify.success('Se actualizó existosamente.');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.router.navigate(['editar-imagen', this.cursoToRegiter.idEtapa, this.cursoToRegiter.id]);
      });
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }
}
