import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MovieService } from '../../services/movie';  
import { Movie } from '../../models/movie.model';
import { RouterModule } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {

  movies$!: Observable<Movie[]>;
  defaultMovieCount: number = 4;
  constructor(private movieService: MovieService)
  {}

  ngOnInit(): void {
    this.movies$ = this.movieService.getLatestMovies(this.defaultMovieCount);
    
  }
}
