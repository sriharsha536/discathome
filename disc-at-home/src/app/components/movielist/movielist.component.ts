import { Component, OnInit } from '@angular/core';
import { Movielist } from 'src/app/_models/movielist';

@Component({
  selector: 'app-movielist',
  templateUrl: './movielist.component.html',
  styleUrls: ['./movielist.component.css']
})
export class MovieListComponent implements OnInit {
  movies: Movielist[];
  constructor() { }

  ngOnInit(): void {
  }

}
