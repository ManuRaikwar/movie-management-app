import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MovieService } from '../../services/movie';
import { Movie } from '../../models/movie.model';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-movie-details',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movie!: Movie;
  isEditMode: boolean = false;
  fields: any[] = [];

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
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.movieService.getMovieById(id).subscribe((res: any) => {
      this.movie = res;
    });
  }

  enableEdit() {
    this.isEditMode = true;
  }

  updateMovie() {
    if(!this.movie.id) return;

    this.movieService.updateMovie(this.movie.id, this.movie).subscribe({
      next: () => {
        this.isEditMode = false;
        this.toast.show('Movie updated successfully', 'success');
      },
        error: () => {
          this.toast.show('Failed while updating the movie', 'error');
        }
      });
  }

  deleteMovie() {
    if (!confirm('Are you sure you want to delete this movie?')) return;

    if(!this.movie.id) return;

    this.movieService.deleteMovie(this.movie.id).subscribe({
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