import { Component, signal } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ToastComponent } from './shared/toast.component/toast.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ToastComponent, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  protected readonly title = signal('movie-management-ui');
}
