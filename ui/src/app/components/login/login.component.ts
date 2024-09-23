import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import {
  FormControl,
  FormGroupDirective,
  NgForm,
  Validators,
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth/auth.service';
import { Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../services/notification/notification.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule,
    CommonModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent {
  constructor(
    private authService: AuthService,
    private notification: NotificationService,
    private router: Router
  ) {}
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });
  matcher = new MyErrorStateMatcher();
  hide = true;

  togglePasswordVisibility(event: MouseEvent) {
    this.hide = !this.hide;
    event.stopPropagation();
  }

  onLogin() {
    try {
      if (this.loginForm.valid) {
        const loginData: object = {
          email: this.loginForm.get('email')?.value,
          password: this.loginForm.get('password')?.value,
        };
        const response = this.authService.loginService(loginData);
        response.subscribe(
          (response: any) => {
            if (response.isAuthenticated) {
              localStorage.setItem('access_token', response.token);
              this.notification.openSnackBar(response.message, '');
              this.router.navigateByUrl('dashboard');
            }
          },
          (error: HttpErrorResponse) => {
            console.log(error.error);
            this.notification.openSnackBar(error.error.message, '');
          }
        );
      }
    } catch (error) {
      this.notification.openSnackBar('Network error. Please try again', '');
    }
  }
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    return !!(
      control &&
      control.invalid &&
      (control.dirty || control.touched || isSubmitted)
    );
  }
}
