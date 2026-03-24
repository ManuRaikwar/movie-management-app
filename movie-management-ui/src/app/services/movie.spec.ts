import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { MovieService } from './movie';
import { Movie } from '../models/movie.model';

describe('MovieService', () => {
  let service: MovieService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [MovieService]
    });
    service = TestBed.inject(MovieService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should fetch latest movies', () => {
    const dummyMovies: Movie[] = [
      { id: 1, title: 'Movie 1', directors: '', actors: '', genres: '', rating: 0, imageUrl: '', releaseDate: '', runningTimeSecs: 0 },
      { id: 2, title: 'Movie 2', directors: '', actors: '', genres: '', rating: 0, imageUrl: '', releaseDate: '', runningTimeSecs: 0 }
    ];

    service.getLatestMovies(2).subscribe(movies => {
      expect(movies.length).toBe(2);
      expect(movies).toEqual(dummyMovies);
    });

    const req = httpMock.expectOne(`${service['baseUrl']}/latest?count=2`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyMovies);
  });
});