import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from './environment-url.service';
import { User } from 'src/app/models/user';
import { RegistrationResponseDto } from 'src/app/response/registration-response-dto';
import { UserLoginDto } from 'src/app/models/user-login-dto';
import { AuthResponseDto } from 'src/app/response/auth-response-dto';
import { Subject } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
private baseUrl:string = "https://localhost:7258/api/Authentication/"
private authChangeSub = new Subject<boolean>()
public authChanged = this.authChangeSub.asObservable();
constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private jwtHelper: JwtHelperService){}

public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
  this.authChangeSub.next(isAuthenticated);
}

  public signUp = (route: string, body: User) => {
    return this.http.post<RegistrationResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;}

    
    public loginUser = (route: string, body: UserLoginDto) => {
      return this.http.post<AuthResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

// signUp(userObj:any){
// return this.http.post<any>(`${this.baseUrl}register`, userObj)
// }

signIn(loginObj:any){
  return this.http.post<any>(`${this.baseUrl}login`, loginObj)
  }

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
  
}




