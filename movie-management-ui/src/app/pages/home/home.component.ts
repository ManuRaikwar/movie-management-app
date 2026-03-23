import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MovieService } from '../../services/movie';  
import { Movie } from '../../models/movie.model';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {

  movies: Movie[] = [];
  defaultMovieCount: number = 4;
  constructor(private movieService: MovieService)
  {}

  ngOnInit(): void {
    this.movieService.getLatestMovies(this.defaultMovieCount).subscribe((res: any) => {
      
      this.movies = res;
      console.log('api res', this.movies);
    })
  }
}
