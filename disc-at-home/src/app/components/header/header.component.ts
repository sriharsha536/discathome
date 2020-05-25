import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DataService } from 'src/app/_services/data/data.service';
import { Observable } from 'rxjs';
import {
  debounceTime,
  tap,
  switchMap,
  distinctUntilChanged,
} from 'rxjs/operators';
import { MovieSearch } from 'src/app/_models/moviesearch.model';
import { AuthenticationService } from 'src/app/_services/authentication/authentication.service';
import { Register } from 'src/app/_models/register';

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
  moviesResult: Observable<MovieSearch[]>;

  currentUser: Register;
  isUserExists: boolean;

  constructor(private dataService: DataService, private authService: AuthenticationService) {
    this.authService.currentUser.subscribe((data) => {
        this.currentUser = data;
    });
  }

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
