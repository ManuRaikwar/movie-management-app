import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MovieService } from '../../services/movie';
import { RouterModule } from '@angular/router';
import { Movie } from '../../models/movie.model';

@Component({
  selector: 'app-search',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {

  searchBy: string = 'Title';
  value: string = '';
  movies: Movie[] = [];

  constructor(private movieService: MovieService) {}

  search() {
    if (!this.value) return;

    this.movieService.searchMovies(this.searchBy, this.value)
      .subscribe((res: any) => {
        this.movies = res;
      });
  }
}