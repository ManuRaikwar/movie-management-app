import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Movie } from '../models/movie.model';
import { catchError, throwError } from 'rxjs';
import { ToastService } from './toast.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private baseUrl = 'https://localhost:44385/api/movie';

  constructor(private http: HttpClient, private toast: ToastService) {}

  private handleError = (err : any) => {
    this.toast.show('API error occurred', 'error');
        return throwError(() => err);
  }

  getLatestMovies(count: number) {
    return this.http.get<Movie[]>(`${this.baseUrl}/latest?count=${count}`).pipe(catchError(this.handleError));
  }

  getAllMovies() {
    return this.http.get<Movie[]>(this.baseUrl).pipe(catchError(this.handleError));
  }

  getMovieById(id: number) {
    return this.http.get<Movie>(`${this.baseUrl}/${id}`).pipe(catchError(this.handleError));
  }

  searchMovies(searchBy: string, value: string) {
    return this.http.get<Movie[]>(`${this.baseUrl}/search?searchBy=${searchBy}&value=${value}`).pipe(catchError(this.handleError));
  }

  addMovie(movie: Movie) {
    return this.http.post(this.baseUrl, movie).pipe(catchError(this.handleError));
  }

  updateMovie(id: number, movie: Movie) {
    return this.http.put(`${this.baseUrl}/${id}`, movie).pipe(catchError(this.handleError));
  }

  deleteMovie(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`).pipe(catchError(this.handleError));
  }  
}
