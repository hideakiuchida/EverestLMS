import { Component, OnChanges, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Router } from '@angular/router';
import { RoleEnum } from 'src/app/enums/roles';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnChanges {
  model: any = {};
  idParticipante: any;
  administratorRole: any;
  sherpaRole: any;
  escaladorRole: any;

  constructor(public authService: AuthService, private router: Router, private alertify: AlertifyService) { }

  ngOnChanges() {
    this.administratorRole = RoleEnum.Administrador;
    this.sherpaRole = RoleEnum.Sherpa;
    this.escaladorRole = RoleEnum.Escalador;
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Bienvenido');
      this.idParticipante = this.authService.getUserId();
      this.router.navigate(['']);
    }, error => {
      if (error.status === 401) {
        this.alertify.error('Error al ingresar sus credenciales');
      } else {
        this.alertify.error(error.error);
      }
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Hasta luego');
    this.router.navigate(['']);
  }

}
