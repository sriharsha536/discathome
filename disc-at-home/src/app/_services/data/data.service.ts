import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map } from 'rxjs/operators';

import { environment } from "src/environments/environment";
import { Observable } from 'rxjs';
import { MovieSearch } from 'src/app/_models/moviesearch.model';

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

  getMovies(searchText): Observable<MovieSearch[]>{
    return this.http.get<MovieSearch[]>(this.baseUrl + 'movies/' + searchText)
    .pipe(
      map(movies => {
        return movies;
      })
    );
  }
}
