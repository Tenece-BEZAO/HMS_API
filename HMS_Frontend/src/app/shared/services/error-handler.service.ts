import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Router } from '@angular/router';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ErrorModalComponent } from '../modals/error-modal/error-modal.component';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements HttpInterceptor{
  constructor(private router: Router) { }
  // intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //   return next.handle(req)
  //   .pipe(
  //     catchError((error: HttpErrorResponse) => {
  //       let errorMessage = this.handleError(error);
  //       return throwError(() => new Error(errorMessage));
  //     })
  //   )
  // }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const localToken = localStorage.getItem('token');
    req = req.clone({headers:req.headers.set('Authorization', 'bearer' + localToken)})
    return next.handle(req)
    .pipe(
      retry(1),
      catchError((error: HttpErrorResponse) => {
        let errorMessage = '';
        if(error.error instanceof ErrorEvent){
          errorMessage = `Error: ${error.error.message}`
        }else{
          errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`
        }
         errorMessage = this.handleError(error);
        return throwError(() => new Error(errorMessage));
      })
    )
  }

  private handleError = (error: HttpErrorResponse) : string => {
    if(error.status === 404){
      return this.handleNotFound(error);
    }
    else if(error.status === 400){
      return this.handleBadRequest(error);
    }
    else if(error.status === 401) {
      return this.handleUnauthorized(error);
    }
    else if(error.status === 403) {
      return this.handleForbidden(error);
    }
    return "server error"
  }
  

  private handleNotFound = (error: HttpErrorResponse): string => {
    this.router.navigate(['/404']);
    
    return error.message;
  }
  

  private handleBadRequest = (error: HttpErrorResponse): string => {
    if(this.router.url === '/authentication/register'){
      let message = '';
      const values = Object.values(error.error.errors);
      values.map((m: any) => {
         message += m as string + '<br>';
      })
  
      return message.slice(0, -4);
    }
    else{
      //return throwError (errMsg)
      return error.error ? error.error : error.message;
    }
  }


  private handleUnauthorized = (error: HttpErrorResponse) => {
    if(this.router.url.startsWith('/authentication/login')) {
      //return 'Authentication failed. Wrong Username or Password';
      return error.error.errorMessage;
    }
    else {
      //this.router.navigate(['/authentication/login']);
      this.router.navigate(['/authentication/login'], { queryParams: { returnUrl: this.router.url }});

      return error.message;
    }
  }


  private handleForbidden = (error: HttpErrorResponse) => {
    this.router.navigate(["/forbidden"], { queryParams: { returnUrl: this.router.url }});
    return "Forbidden";
  }
  
  
  // public errorMessage: string = '';

  // constructor(private router: Router, private modal: BsModalService) { }

  // public handleError = (error: HttpErrorResponse) => {
  //   if (error.status === 500) {
  //     this.handle500Error(error);
  //   }
  //   else if (error.status === 404) {
  //     this.handle404Error(error)
  //   }
  //   else {
  //     this.handleOtherError(error);
  //   }
  // }

  // private handle500Error = (error: HttpErrorResponse) => {
  //   this.createErrorMessage(error);
  //   this.router.navigate(['/500']);
  // }

  // private handle404Error = (error: HttpErrorResponse) => {
  //   this.createErrorMessage(error);
  //   this.router.navigate(['/404']);
  // }
  // private handleOtherError = (error: HttpErrorResponse) => {
  //   this.createErrorMessage(error);

  //   const config: ModalOptions = {
  //     initialState: {
  //       modalHeaderText: 'Error Message',
  //       modalBodyText: this.errorMessage,
  //       okButtonText: 'OK'
  //     }
  //   };
  //   this.modal.show(ErrorModalComponent, config);
  // }

  // private createErrorMessage = (error: HttpErrorResponse) => {
  //   this.errorMessage = error.error ? error.error : error.statusText;
  // }
  
}
