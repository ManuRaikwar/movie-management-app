import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { MovieService } from '../../services/movie';
import { Movie } from '../../models/movie.model';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-add-movie',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent {

  genres = ['Action', 'Adventure', 'Family', 'Fantasy', 'Sci-Fi', 'Thriller'];

  selectedGenre: string = '';

  movie: Movie = {
    title: '',
    directors: '',
    actors: '',
    genres: '',
    rating: null,
    imageUrl: '',
    releaseDate: '',
    runningTimeSecs: null
  };

  constructor(private movieService: MovieService, private router: Router, private toast: ToastService) {}

  addMovie() {
    if (!this.movie.title || !this.movie.directors || !this.movie.actors) {
      this.toast.show('Please fill required fields', 'error');
      return;
    }

    this.movie.genres = this.selectedGenre;

    this.movieService.addMovie(this.movie)
      .subscribe({
        next: () => {
          this.toast.show('Movie added successfully', 'success');
          this.router.navigate(['/']);
        },
        error: () => {
          this.toast.show('Failed to add the movie', 'error');
        }
      },
    );
  }
}