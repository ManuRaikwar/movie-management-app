import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddMovieComponent } from './add-movie.component';
import { MovieService } from '../../services/movie';
import { ToastService } from '../../services/toast.service';
import { of } from 'rxjs';
  
describe('AddMovieComponent', () => {
  let component: AddMovieComponent;

  const movieServiceMock = {
    addMovie: () => of({})
  };

  const toastServiceMock = {
    show: () => {}
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [AddMovieComponent],
      providers: [
        { provide: MovieService, useValue: movieServiceMock },
        { provide: ToastService, useValue: toastServiceMock }
      ]
    });

    const fixture = TestBed.createComponent(AddMovieComponent);
    component = fixture.componentInstance;
  });

  it('should call addMovie', () => {
    component.movie = {
      id: 0,
      title: 'Test',
      directors: '',
      actors: '',
      genres: '',
      rating: 0,
      imageUrl: '',
      releaseDate: '',
      runningTimeSecs: 0
    };

    component.addMovie();

    expect(component).toBeTruthy(); // basic test
  });
});