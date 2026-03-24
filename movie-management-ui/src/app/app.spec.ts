import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { MovieService } from './services/movie';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute } from '@angular/router';

describe('App', () => {

  let component: AppComponent;

  const mockActivatedRoute = {
    snapshot: {
      paramMap: {
        get: () => null
      }
    }
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, AppComponent, RouterTestingModule],
      providers: [
        {
          provide: ActivatedRoute, useValue:mockActivatedRoute
        }
      ]
    });

    const fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
  });


  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should render title', async () => {
    const fixture = TestBed.createComponent(AppComponent);
    await fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.textContent).toContain('Movie App');
    expect(compiled.textContent).toContain('Home');
    expect(compiled.textContent).toContain('Search Movies');
    expect(compiled.textContent).toContain('Add Movie');
  });
});
