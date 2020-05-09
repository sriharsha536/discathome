import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../../_models/movie.model';
import { map } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  public baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getMovies(searchText): Observable<Movie[]>{
    return this.http.get<Movie[]>(this.baseUrl + 'movies/' + searchText)
    .pipe(
      map(movies => {
        return movies;
      })
    );
  }
}
