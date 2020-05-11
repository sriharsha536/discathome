import { Component, OnInit } from '@angular/core';
import { Register } from 'src/app/_models/register';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services/authentication/authentication.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-loadusercontrol',
  templateUrl: './loadusercontrol.component.html',
  styleUrls: ['./loadusercontrol.component.css'],
})
export class LoadusercontrolComponent implements OnInit {
  currentUser: Register;
  isLoggedIn: Observable<boolean>;
  isUserExists: boolean;
  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {
    this.authService.currentUser.subscribe((data) => {
      this.currentUser = data;
    });
  }

  ngOnInit(): void {}

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
