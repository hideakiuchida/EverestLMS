import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { AlertifyService } from '../services/alertify/alertify.service';

export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) {}

    canActivate(): boolean {
        if (this.authService.loggedIn()) {
            return true;
        }

        this.alertify.error('No se encuentra logeado');
    }
    
}