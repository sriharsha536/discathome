import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Register } from "src/app/_models/register";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  register(user: Register)
  {
    return this.http.post(this.baseUrl + 'auth/register', user);
  }
}
