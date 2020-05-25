import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieSearch } from '../../_models/moviesearch.model';
import { map } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  public baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getMovies(searchText): Observable<MovieSearch[]>{
    return this.http.get<MovieSearch[]>(this.baseUrl + 'movies/' + searchText)
    .pipe(
      map(movies => {
        return movies;
      })
    );
  }
}
