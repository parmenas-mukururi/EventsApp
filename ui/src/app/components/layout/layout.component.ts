import { Component } from '@angular/core';
import { SidenavComponent } from "../sidenav/sidenav.component";
import { DashboardComponent } from "../dashboard/dashboard.component";
import { HeaderComponent } from "../header/header.component";
import { FooterComponent } from "../footer/footer.component";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [SidenavComponent, DashboardComponent, HeaderComponent, FooterComponent],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

}
