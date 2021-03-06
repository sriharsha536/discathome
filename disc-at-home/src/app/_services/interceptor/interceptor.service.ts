import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class InterceptorService implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let requestUrl = '';
    req = req.clone({
      headers: req.headers.set(
        'Authorization',
        'Bearer ' + localStorage.getItem('token')
      ),
      url: requestUrl + '' + req.url,
    });
    return next.handle(req);
  }
}
