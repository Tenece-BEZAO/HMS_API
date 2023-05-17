import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { EnvironmentUrlService } from './environment-url.service';
import { User } from 'src/app/models/user';
import { RegistrationResponseDto } from 'src/app/response/registration-response-dto';
import { UserLoginDto } from 'src/app/models/user-login-dto';
import { AuthResponseDto } from 'src/app/response/auth-response-dto';
import { Observable, Subject, throwError, catchError, flatMap } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ForgotPassword } from 'src/app/models/forgot-password';
import { CustomEncoder } from '../custom-encoder';
import { SocialAuthService, SocialUser } from "@abacritt/angularx-social-login";
import { GoogleLoginProvider } from "@abacritt/angularx-social-login";
import { ExternalAuthDto } from 'src/app/models/external-auth-dto';
import { Router } from '@angular/router';
import { TwoFactorDto } from 'src/app/response/two-factor-dto';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit{
private baseUrl:string = "https://localhost:7258/api/Authentication/"
private authChangeSub = new Subject<boolean>()
public authChanged = this.authChangeSub.asObservable();
private extAuthChangeSub = new Subject<SocialUser>();;
public extAuthChanged = this.extAuthChangeSub.asObservable();
public isExternalAuth?: boolean;
private authenticated = false;
private redirectUrl?: string;

constructor(private http: HttpClient, private envUrl: EnvironmentUrlService,
  private externalAuthService: SocialAuthService,private jwtHelper: JwtHelperService){
    
  }
  ngOnInit(): void {
    this.externalAuthService.authState.subscribe((user) => {
      console.log(user)
      this.extAuthChangeSub.next(user);
      this.isExternalAuth = true;
    })
    
  }

  public setRedirectUrl(url: string) {
    this.redirectUrl = url;
  }
  // public signInWithExternalProvider(provider: string): void {
  //   this.externalAuthService.signIn(provider).then(user => {
  //     const externalAuth: ExternalAuthDto = {
  //       provider: user.provider,
  //       idToken: user.idToken
  //     }
  //     this.validateExternalAuth(externalAuth);
  //   });
  // }
  public signInWithGoogle = ()=> {
    this.externalAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }
  
  public signOutExternal = () => {
    this.externalAuthService.signOut();
  }

  public GoogleLogin = (route: string, body: ExternalAuthDto) => {
    //this.externalAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
    return this.http.post<AuthResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }


public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
  this.authChangeSub.next(isAuthenticated);
}

  public signUp = (route: string, body: User):Observable<any> => {
    return this.http.post<RegistrationResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }
  // public signUp = (route: string, body: User): Observable<{ userId: string, response: RegistrationResponseDto }> => {
  //   return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body)
  //     .pipe(
  //       map(response => ({ userId: response.userId, response }))
  //     );
  // }
  
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;}

    
    public loginUser = (route: string, body: UserLoginDto):Observable<any>  => {
      return this.http.post<AuthResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body)
      // .pipe(flatMap(
      //   Response => this.secondFactor(Response.token)
      // ))
    }
//     public secondFactor(token: string) :Observable<any>{
// const httpOptions = {
//   headers: new HttpHeaders({
//     'Token': token,})
// }
//     }

// signUp(userObj:any){
// return this.http.post<any>(`${this.baseUrl}register`, userObj)
// }

// signIn(loginObj:any){
//   return this.http.post<any>(`${this.baseUrl}login`, loginObj)
//   }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('access_token');
    return token !== null && !this.jwtHelper.isTokenExpired(token);
  }

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token");
    const decodedToken = this.jwtHelper.decodeToken(token as string);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
  
    return role === 'SuperUser';

  }

  public forgotPassword = (route: string, body: ForgotPassword) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  public confirmEmail = (route: string, token: string, email: string) => {
    let params = new HttpParams({ encoder: new CustomEncoder() })
    params = params.append('token', token);
    params = params.append('email', email);
  
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress), { params: params });
  }


  public enableTwoFactorAuth = ( userId: string) => {
    //return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), userId);
    return this.http.post(`${this.baseUrl}/Authentication/enabletwofactorauth`, { userId });
  }
  public twoStepLogin = (route: string, body: TwoFactorDto) => {
    return this.http.post<AuthResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }
  sendVerificationCode(email: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/auth/sendcode`, { email });
  }

  verifyCode(code: string): Observable<any> {
    const token = localStorage.getItem('token')
    const url = `${this.baseUrl}/api/Authentication/verifycode?code=${code}`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(url, { headers });
    //return this.http.post(url, { headers: headers });

  }
}




