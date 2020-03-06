import { Component, OnInit } from '@angular/core';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Etapa } from 'src/app/models/etapa';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Nivel } from 'src/app/models/nivel';
import { Dificultad } from 'src/app/models/dificultad';
import { Idioma } from 'src/app/models/idioma';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CursoToRegister } from 'src/app/models/cursoToRegister';

@Component({
  selector: 'app-registrar-curso',
  templateUrl: './registrar-curso.component.html',
  styleUrls: ['./registrar-curso.component.css']
})
export class RegistrarCursoComponent implements OnInit {
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  etapas: Etapa[];
  dificultades: Dificultad[];
  idiomas: Idioma[];
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  cursoForm: FormGroup;
  cursoToRegiter: CursoToRegister;
  idCurso: number;

  constructor(private formBuilder: FormBuilder, private cursoService: CursosService, private etapaService: EtapaService,
              private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.niveles = data.niveles;
      this.lineaCarreras = data.lineaCarreras;
      this.idiomas = data.idiomas;
      this.dificultades = data.dificultades;
    });
    this.createCursonForm();
  }

  createCursonForm() {
    this.cursoForm = this.formBuilder.group({
      nombre: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      descripcion: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
      idNivel: ['', [Validators.required]],
      idLineaCarrera: ['', [Validators.required]],
      idEtapa: ['', [Validators.required]],
      idDificultad: ['', [Validators.required]],
      idIdioma: ['', [Validators.required]],
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

  loadEtapas(idLineaCarrera, idNivel) {
    this.etapaService.getEtapas(idLineaCarrera, idNivel, null).subscribe((etapas: Etapa[]) => {
       this.etapas = etapas;
       this.cursoForm.controls.idEtapa.setValue(this.etapas[0].id);
    }, error => {
      this.alertify.error(error.message);
    });
  }

  registrarCurso() {
    if (this.cursoForm.valid) {
      this.cursoToRegiter = Object.assign({}, this.cursoForm.value);
      this.cursoToRegiter.idDificultad = +this.cursoToRegiter.idDificultad;
      this.cursoToRegiter.idIdioma = +this.cursoToRegiter.idIdioma;
      this.cursoToRegiter.idLineaCarrera = +this.cursoToRegiter.idLineaCarrera;
      this.cursoToRegiter.idNivel = +this.cursoToRegiter.idNivel;
      this.cursoToRegiter.autor = 'Alonso Uchida'; // TODO cambiar por usuario del Token
      this.cursoToRegiter.imagen = 'Imagen 1';
      this.cursoService.createCurso(this.cursoToRegiter.idEtapa, this.cursoToRegiter).subscribe((idCurso: number) => {
        this.idCurso = idCurso;
        this.alertify.success('Se registró existosamente.');
      }, error => {
        this.alertify.error(error.message);
      }, () => {
        this.router.navigate(['editar-imagen', this.cursoToRegiter.idEtapa, this.idCurso]);
      });
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }
}
