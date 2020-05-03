import { Component } from '@angular/core';
import { Router } from "@angular/router";

import { AuthenticationService } from "./_services/authentication/authentication.service";
import { Register } from "./_models/register";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentUser: Register;
  constructor(private router: Router, private authenticationService: AuthenticationService){
    this.authenticationService.currentUser.subscribe(data => {
      this.currentUser = data;
    });
  }

  logout(){
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

}
