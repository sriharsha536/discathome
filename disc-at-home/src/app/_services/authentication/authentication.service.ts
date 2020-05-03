import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Register } from 'src/app/_models/register';
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<Register>;
  public currentUser: Observable<Register>;
  public baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<Register>(
      JSON.parse(localStorage.getItem('currentUser'))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  /**
   * currentUserValue : Register
   * This method will return the current user registration object.*/
  public currentUserValue(): Register {
    return this.currentUserSubject.value;
  }

  login(email: string, password: string) {
    return this.http
      .post<any>(this.baseUrl + 'auth/login', { email, password })
      .pipe(
        map((user) => {
          if (user && user.token) {
            localStorage.setItem('currentUser', JSON.stringify(user.result));
            this.currentUserSubject.next(user);
          }
          return user;
        })
      );
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
