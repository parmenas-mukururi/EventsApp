import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent implements OnInit {
  user: any = null;

  constructor(private router: Router, private authService: AuthService) {}
  navigateToLoginPage() {
    this.router.navigateByUrl('login');
  }

  logout() {
    this.authService.logout();
    this.user = null;
    this.navigateToLoginPage();
  }

  ngOnInit(): void {
    this.user = this.authService.getUserInfo();
  }
}
