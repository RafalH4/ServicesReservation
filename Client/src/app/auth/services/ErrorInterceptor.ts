import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor
{
    intercept(req : HttpRequest<any>, next : HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req).pipe(
            retry(1),
            catchError((error: HttpErrorResponse) =>{

                if (error.status === 401 || error.status === 403) {
                    alert("Brak autoryzacji")
                  }
                  alert(error.error)
                  return throwError(error);
                
            })
        )

    }

}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
}