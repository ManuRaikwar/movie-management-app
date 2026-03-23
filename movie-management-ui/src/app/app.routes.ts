import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { SearchComponent } from './pages/search/search.component';
import { MovieDetailsComponent } from './pages/movie-details/movie-details.component';
import { AddMovieComponent } from './pages/add-movie.component/add-movie.component';

export const routes: Routes = [
    { path: '', component: HomeComponent},
    { path: 'search', component: SearchComponent},
    { path: 'movie/:id', component: MovieDetailsComponent},
    { path: 'add', component: AddMovieComponent}
];
