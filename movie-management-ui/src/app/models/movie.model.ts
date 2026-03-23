export interface Movie {
  id?: number;
  title: string;
  directors: string;
  actors: string;
  genres: string;
  rating: number | null;
  imageUrl: string;
  releaseDate: string;
  runningTimeSecs: number | null;
}