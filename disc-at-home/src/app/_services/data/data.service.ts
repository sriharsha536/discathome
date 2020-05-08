import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, debounceTime, switchMap, takeUntil, skip } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}

  getStates(): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'states').pipe(
      map((states) => {
        return states;
      })
    );
  }

  getCities(stateId): Observable<any> {
    return this.http
      .get<any>(this.baseUrl + 'states/' + stateId + '/cities')
      .pipe(
        map((cities) => {
          return cities;
        })
      );
  }

  getMovies(searchText) {
    const behaviourSubject = new BehaviorSubject('');
    const result = behaviourSubject.pipe(
      debounceTime(500),
      switchMap((map) =>
        this.getAutoSuggestionsForMovies(searchText).pipe(
          takeUntil(behaviourSubject.pipe(skip(1)))
        )
      )
    );
  }

  getAutoSuggestionsForMovies(searchText): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'moviessearch/' + searchText).pipe(
      map((movies) => {
        return movies;
      })
    );
  }
}
