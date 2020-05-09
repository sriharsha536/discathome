import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/_services/data/data.service';
import { Observable } from 'rxjs';
import {
  startWith,
  map,
  debounceTime,
  tap,
  switchMap,
  finalize,
  distinctUntilChanged,
} from 'rxjs/operators';
import { Movie } from 'src/app/_models/movie.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  myplaceHolder: string = 'Search Movie..';
  searchForm: FormGroup;
  searchBoxCtrl = new FormControl();
  isLoading = false;
  moviesResult: Observable<Movie[]>;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {
    this.searchForm = new FormGroup({});
    this.searchBoxCtrl = new FormControl();
    this.moviesResult = this.searchBoxCtrl.valueChanges.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      tap(_ => (this.isLoading = true)),
      switchMap(searchText => this.dataService.getMovies(searchText)),
      tap(_ => (this.isLoading = false))
    );
  }

  checkPlaceHolder() {
    if (this.myplaceHolder) {
      this.myplaceHolder = null;
      return;
    } else {
      this.myplaceHolder = 'Search Movie..';
      return;
    }
  }
}
