import { Component, OnInit} from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';
import { FormBuilder, FormGroup,FormControl ,Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthResponseDto } from 'src/app/response/auth-response-dto';
import { HttpErrorResponse } from '@angular/common/http';
import { TwoFactorDto } from 'src/app/response/two-factor-dto';
@Component({
  selector: 'app-two-factor',
  templateUrl: './two-factor.component.html',
  styleUrls: ['./two-factor.component.css']
})
export class TwoFactorComponent implements OnInit {
  twoStepForm: FormGroup<any> = new FormGroup({});
  private provider?: string;
  private email?: string;
  private returnUrl?: string;
  
  //twoStepForm: FormGroup;
  showError?: boolean;
  errorMessage?: string;
  // codeForm: FormGroup;
  // errorMessage = '';
  // loading = false;
  // verificationCode = '';

  constructor(private fb: FormBuilder, private route: Router, private router: ActivatedRoute,
    private authService: AuthService,){

    }

    ngOnInit(): void {

      // this.router.queryParams.subscribe(params => {
      //   this.provider = params.provider;
      //   this.email = params.email;
      //   this.returnUrl = params.returnUrl;})
      
      //this.twoStepForm = new FormGroup({
        this.twoStepForm = this.fb.group({
        twoFactorCode: new FormControl('', [Validators.required]),
      });
      
        this.provider = this.router.snapshot.queryParams['provider'];
        this.email = this.router.snapshot.queryParams['email'];
        this.returnUrl = this.router.snapshot.queryParams['returnUrl'];

//     verifyCode() {
//       this.verificationCode = this.codeForm.value.code;
//       this.loading = true;
//       this.authService.verifyCode(this.verificationCode).subscribe({
//        this.authService.verifyCode(this.codeForm.value.code).subscribe({
//         next: () => {
//           this.loading = false;
//           this.route.navigate(['/home'])
//            redirect to the dashboard or home page
//         },
//         error: (err) => {
//           this.loading = false;
//           this.errorMessage = err.error || 'Failed to verify the code. Please try again.';
//         },
//       });
// }
}
validateControl = (controlName: string) => {
  return this.twoStepForm?.get(controlName)?.invalid && this.twoStepForm?.get(controlName)?.touched
}
hasError = (controlName: string, errorName: string) => {
  return this.twoStepForm?.get(controlName)?.hasError(errorName)
}
loginUser = (twoStepFromValue: any) => {
  this.showError = false;
  
  const formValue = { ...twoStepFromValue };
  let twoFactorDto: TwoFactorDto = {
    email: this.email || '',
    provider: this.provider || '',
    token: formValue.twoFactorCode
  }
  this.authService.twoStepLogin('Authentication/TwoStepVerification', twoFactorDto)
  .subscribe({
    next: (res:AuthResponseDto) => {
      localStorage.setItem("token", res.token);
      this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
      this.route.navigate([this.returnUrl]);
    },
    error: (err: HttpErrorResponse) => {
      this.errorMessage = err.message;
      this.showError = true;
    }
  })
}  }
