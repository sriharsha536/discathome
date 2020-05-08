import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/_services/data/data.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  searchForm: FormGroup;
  loading = false;

  constructor(
    private formbuilder: FormBuilder,
    private router: Router,
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    this.searchForm = this.formbuilder.group({

    });
  }
}
