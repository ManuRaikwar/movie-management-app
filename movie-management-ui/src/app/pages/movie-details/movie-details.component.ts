import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MovieService } from '../../services/movie';
import { Movie } from '../../models/movie.model';
import { ToastService } from '../../services/toast.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-movie-details',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movie$!: Observable<Movie>;
  movie!: Movie;
  isEditMode: boolean = false;
  fields: any[] = [];
  id!: number

  constructor(private route: ActivatedRoute, private movieService: MovieService,
               private router: Router, private toast: ToastService
  ) {}

  ngOnInit(): void {

    this.fields = [
                  { key: 'directors', label: 'Director', type: 'text' },
                  { key: 'actors', label: 'Actors', type: 'text' },
                  { key: 'genres', label: 'Genre', type: 'text' },
                  { key: 'rating', label: 'Rating', type: 'number' }
                  ];
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.movie$ = this.movieService.getMovieById(this.id);
  }

  enableEdit() {
    this.isEditMode = true;
  }

  updateMovie(movie: Movie) {
  if (!this.id) return;
  this.movieService.updateMovie(this.id, movie).subscribe({
    next: () => this.toast.show('Movie updated!', 'success'),
    error: () => this.toast.show('Failed to update!', 'error')
  });
}

  deleteMovie() {
    if (!confirm('Are you sure you want to delete this movie?')) return;

    if(!this.id) return;

    this.movieService.deleteMovie(this.id).subscribe({
      next: () => {
         this.toast.show('Movie deleted', 'success');
        this.router.navigate(['/']);
      },
      error: () => {
        this.toast.show('Failed while deleting the movie', 'error');
      }       
      });
  }
}