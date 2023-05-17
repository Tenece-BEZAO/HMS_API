import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { User } from 'src/app/models/user';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ModalOptions, BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { SuccessModalComponent } from 'src/app/shared/modals/success-modal/success-modal.component';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/shared/services/auth.service';
import { PasswordConfirmationValidatorService } from 'src/app/shared/custom-validators/password-confirmation-validator.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
// template: `<div>hello</div>`,
@Component({
  selector: 'app-register',
   templateUrl: './register.component.html',

  styleUrls: ['./register.component.css']
})

export class RegisterComponent {
  
    registerForm!: FormGroup;
    errorMessage : string = '';
    enableTwoFactorAuth = false;

    //bsModalRef?: BsModalRef;
    public showError?: boolean;
    constructor(private repo: RepositoryService, private router: Router, private datePipe: DatePipe, private auth: AuthService, private route: Router,
      private passConfValidator: PasswordConfirmationValidatorService,private errorHandler: ErrorHandlerService, private modal: BsModalService){}


    ngOnInit(): void {
      this.registerForm = new FormGroup({
        firstName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
        lastName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
        userName: new FormControl('', [Validators.required, Validators.maxLength(60)]),
        email: new FormControl('', [Validators.required, Validators.email]),
        phoneNumber: new FormControl('', [Validators.required, Validators.maxLength(60)]),
        password: new FormControl('', [Validators.required]),
        confirmedpassword: new FormControl(''),
       

      });
const confirmedPassword = this.registerForm.get('confirmedpassword');
const passwordControl = this.registerForm.get('password');
if (confirmedPassword && passwordControl) {
  confirmedPassword.setValidators([Validators.required, this.passConfValidator.validateConfirmPassword(passwordControl)]);
}
    }
    

    
    validateControl = (controlName: string) => {
      if (this.registerForm.get(controlName)?.invalid && this.registerForm.get(controlName)?.touched)
        return true;
      
      return false;
    } 
    
    hasError = (controlName: string, errorName: string) => {
      if (this.registerForm.get(controlName)?.hasError(errorName))
        return true;
      
      return false;
    }
    

    onSubmit(registerFormValue: User){
      if(this.registerForm.valid){
        this.showError = false;
        this.executeUserRegistration(registerFormValue)
          //     this.auth.signUp(this.registerForm.value).subscribe({
            this.auth.signUp("Authentication/register", registerFormValue).pipe(
              
              catchError((error: HttpErrorResponse) => {
                this.errorMessage = error.error.message;
                return throwError(error);
              })
            ).subscribe({
              
              next: (res)=>{
               // alert("successful"); this.registerForm.reset(); this.route.navigate(['login'])},
               if(this.enableTwoFactorAuth){
               // this.auth.enableTwoFactorAuth(res.userId).subscribe(() => {
                
                this.auth.enableTwoFactorAuth(res.userId).subscribe(() => {
                  alert("Two-factor authentication enabled successfully.");
                  this.registerForm.reset();
                  this.route.navigate(['login']);
                }, (err: HttpErrorResponse) => {
                  this.errorMessage = err.message;
                  this.showError = true;
                });
              } else {
                alert("Registration successful.");
                this.registerForm.reset();
                this.route.navigate(['login']);
              }
            },
              error: (err: HttpErrorResponse) => {
                this.errorMessage = err.message;
                this.showError = true;
              }
            })
            
        // this.auth.signUp("Authentication/register", registerFormValue).subscribe({
        //   next: (res)=>{alert("successful"); this.registerForm.reset(); this.route.navigate(['login'])},
        //   error: (err: HttpErrorResponse) => {
        //     this.errorMessage = err.message;
        //     this.showError = true;
        //   }
        // })
        console.log(this.registerForm.value)
      }
    }

    private executeUserRegistration = (registerFormValue : User) =>{
       const defaultDate = new Date('1970-01-01');
     const user: User = {
       firstName: registerFormValue.firstName,
       lastName: registerFormValue.lastName,
       userName: registerFormValue.userName,
       phoneNumber: registerFormValue.phoneNumber,
       password: registerFormValue.password,
       confirmedPasswor: registerFormValue.confirmedPasswor,
       email: registerFormValue.email,
       clientURI: 'http://localhost:7297/authentication/ConfirmEmail'
     }}
     redirectToRegisterUser = () => {
      this.router.navigate(['/auth/register']);
      }  
    
}

 // onSubmit = (registerFormValue : User) => {
    //   if (this.registerForm.valid)
    //     this.executeUserRegistration(registerFormValue);
    // }
    
    // private executeUserRegistration = (registerFormValue : User) =>{
    //  // const transformedDateOfBirth = registerFormValue.dateOfBirth;
      
    //   //const transformedDateOfBirth = this.datePipe.transform(registerFormValue.dateOfBirth, 'yyyy-MM-dd');
    //   const defaultDate = new Date('1970-01-01');
    // const user: User = {
    //   firstName: registerFormValue.firstName,
    //   lastName: registerFormValue.lastName,
    //   userName: registerFormValue.userName,
    //   //dateOfBirth: transformedDateOfBirth ? new Date(transformedDateOfBirth) : new Date(),
    //   phoneNumber: registerFormValue.phoneNumber,
    //   password: registerFormValue.password,
    //   confirmedPasswor: registerFormValue.confirmedPasswor,
    //   email: registerFormValue.email
    // }
    //       const apiUrl = 'Authentication/register';
    //       this.repo.registerUser(apiUrl, user)
    //       .subscribe({
    //         next: (data: User) => {
    //           const config: ModalOptions = {
    //             initialState: {
    //               modalHeaderText: 'Success Message',
    //               modalBodyText: `User: ${data.firstName} created successfully`,
    //               okButtonText: 'OK'
    //             }
    //           };
        
    //           this.bsModalRef = this.modal.show(SuccessModalComponent, config);
    //           this.bsModalRef.content.redirectOnOk.subscribe((_:any) => this.redirectToRegisterUser());
    //         },
    //         error: (err: HttpErrorResponse) => {
    //             this.errorHandler.handleError(err);
    //             this.errorMessage = this.errorHandler.errorMessage;
    //         }
    //       })    
    // }
