import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { data } from '../../constants/testData';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-events',
  standalone: true,
  imports: [MatCardModule, CommonModule, RouterOutlet],
  templateUrl: './events.component.html',
  styleUrl: './events.component.css',
})
export class EventsComponent {
  data = data;
}
