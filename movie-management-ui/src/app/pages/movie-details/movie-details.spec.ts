import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MovieDetailsComponent } from './movie-details.component';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { MovieService } from '../../services/movie';

describe('MovieDetailsComponent', () => {
  let component: MovieDetailsComponent;
  let fixture: ComponentFixture<MovieDetailsComponent>;

  const mockActivatedRoute = {
    snapshot: {
      paramMap: {
        get: (key: string) => '1' // fake movie id
      }
    }
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MovieDetailsComponent], 
      providers: [
        { provide: ActivatedRoute, useValue: mockActivatedRoute }, 
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(MovieDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges(); 
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});