import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserLoginDto } from 'src/app/models/user-login-dto';
import { AuthResponseDto } from 'src/app/response/auth-response-dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{



// users? : User[];
// errorMessage: string = '';
type: string = 'password';
loginForm! : FormGroup;
isText: boolean = false;
errorMessage: string = '';
showError?: boolean;
eyeIcon: string = "fa-eye-slash"
constructor (private fb: FormBuilder,private repo: RepositoryService, private auth: AuthService, 
   private router: ActivatedRoute, private route: Router,private errorHandler: ErrorHandlerService){}


ngOnInit(): void {
  this.loginForm = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  })
  //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
}

hideShowPass(){
  this.isText = !this.isText;
  this.isText? this.eyeIcon = "fa-eye": this.eyeIcon = "fa-eye-slash";
  this.isText? this.type = "text" : this.type = "password"
}

validateControl = (controlName: string) => {
  return this.loginForm.get(controlName)?.invalid && this.loginForm.get(controlName)?.touched
}
hasError = (controlName: string, errorName: string) => {
  return this.loginForm.get(controlName)?.hasError(errorName)
}

onSubmit(loginFormValue : User){
  this.showError = false;
  if(this.loginForm.valid){
console.log(this.loginForm.value);
const user: User = {
  firstName: loginFormValue.firstName,
  lastName: loginFormValue.lastName,
  userName: loginFormValue.userName,
  //dateOfBirth: transformedDateOfBirth ? new Date(transformedDateOfBirth) : new Date(),
  phoneNumber: loginFormValue.phoneNumber,
  password: loginFormValue.password,
  confirmedPasswor: loginFormValue.confirmedPasswor,
  email: loginFormValue.email
}

this.onSubmit = (loginFormValue: UserLoginDto) => {
  this.showError = false;
  const login = {... loginFormValue };
  const userForAuth: UserLoginDto = {
    email: login.email,
    password: login.password
  }
  this.auth.loginUser('Authentication/login', userForAuth)
  .subscribe({
    next: (res:AuthResponseDto) => {
     localStorage.setItem("token", res.token);
     this.auth.sendAuthStateChangeNotification(res.isAuthSuccessful);
     this.route.navigate(['/home']);
  },
  error: (err: HttpErrorResponse) => {
    this.errorMessage = err.message;
    this.showError = true;
  }})
}


// const apiUrl = 'Authentication/login';
//           this.repo.Authenticate(apiUrl, user)
//           .subscribe({
//             next:(res)=>{
//                   alert("login successful");
//                   this.loginForm.reset();
//                   this.route.navigate(['/home'])
//                   //alert(res.Message)
//                 },
//                 error:(err)=>{
//                   alert("error")
//                   //alert(err?.error.Message)
//                 }
//             })
  }else{
    console.log('form is not valid');
    this.validateAllFormFields(this.loginForm);
    alert("your form is invalid")
  }
}



// onSubmit(){
//   if(this.loginForm.valid){
// // console.log(this.loginForm.value)
// this.auth.signIn(this.loginForm.value).subscribe({
//   next:(res)=>{
//     alert("login successful")
//     //alert(res.Message)
//   },
//   error:(err)=>{
//     alert("error")
//     //alert(err?.error.Message)
//   }
// })
//   }else{
//     console.log('form is not valid');
//     this.validateAllFormFields(this.loginForm);
//     alert("your form is invalid")
//   }
// }

private validateAllFormFields(formGroup: FormGroup){
 Object.keys(formGroup.controls).forEach(field =>{
  const control = formGroup.get(field);
  if( control instanceof FormControl){
    control.markAsDirty({onlySelf:true})
  }else if (control instanceof FormGroup){
    this.validateAllFormFields(control)
  }
 })
}

}
