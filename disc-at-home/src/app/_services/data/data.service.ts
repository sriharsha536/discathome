import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs/operators';

import { environment } from "src/environments/environment";
import { Observable } from 'rxjs';
import { Movie } from 'src/app/_models/movie.model';

@Injectable({
  providedIn: 'root'
})

export class DataService {
  public baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  getStates() : Observable<any>
  {
    return this.http.get<any>(this.baseUrl + 'states')
    .pipe(
      map(states => {
          return states;
      })
    );
  }

  getCities(stateId): Observable<any>
  {
    return this.http.get<any>(this.baseUrl + 'states/' + stateId + '/cities')
    .pipe(
      map(cities => {
          return cities;
      })
    );
  }

  getMovies(searchText): Observable<Movie[]>{
    return this.http.get<Movie[]>(this.baseUrl + 'movies/' + searchText)
    .pipe(
      map(movies => {
        return movies;
      })
    );
  }
}
