import { Component, OnInit } from '@angular/core';
import { Observable , of } from 'rxjs';
import { Movie } from 'src/app/_models/movie.model';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, tap, switchMap } from 'rxjs/operators';
import { MovieService } from 'src/app/_services/movie/movie.service';

@Component({
  selector: 'app-moviesearch',
  templateUrl: './moviesearch.component.html',
  styleUrls: ['./moviesearch.component.css']
})
export class MoviesearchComponent implements OnInit {
  loading: boolean = false;
  moviesResult: Observable<Movie[]>;
  searchField: FormControl;
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.searchField = new FormControl();
    this.moviesResult = this.searchField.valueChanges.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      tap(_ => (this.loading = true)),
      switchMap(searchText => {
        if(searchText)
          return this.movieService.getMovies(searchText)
        else {
          this.loading = false;
          return of<Movie[]>([]);;
        }
      }),
      tap(_ => (this.loading = false))
    );
  }
}
