import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataService } from 'src/app/_services/data/data.service';

import { UserService } from 'src/app/_services/user/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  states: {};
  cities: {};

  constructor(
    private formbuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private dataService: DataService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.registerForm = this.formbuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      userName: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      emailId: ['', [Validators.required, Validators.email]],
      contactNo: ['', [Validators.required]],
      streetName: ['', [Validators.required]],
      aptNo: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
      zipCode: ['', [Validators.required]],
    });

    this.dataService.getStates().subscribe((data) => (this.states = data));
  }

  get fval() {
    return this.registerForm.controls;
  }

  onFormSubmit() {
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }

    this.loading = true;
    this.userService.register(this.registerForm.value).subscribe(
      (data) => {
        alert('User Registered Successfully!!');
        this.router.navigate(['/login']);
      },
      (error) => {
        this.toastr.error(error.error.message, 'Error');
        this.loading = false;
      }
    );
  }

  onChangeState(stateId: number) {
    if (stateId) {
      this.dataService.getCities(stateId).subscribe((data) => {
        this.cities = data;
      });
    } else {
      this.cities = {};
    }
  }
}
