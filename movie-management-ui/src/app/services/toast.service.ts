import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  toasts: any[] = [];

  show(message: string, type: 'success' | 'error') {
    const toast = { message, type };
    this.toasts.push(toast);

    setTimeout(() => this.remove(toast), 3000);
  }

  remove(toast: any) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}