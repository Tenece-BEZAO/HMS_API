import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from 'src/app/models/user';
import { EnvironmentUrlService } from './environment-url.service';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { RegistrationResponseDto } from 'src/app/response/registration-response-dto';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }


  //  public registerUser = (route: string, body: User) => {
  //   return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  // }

  // registerUsers(): Observable<string[]>{
  //   return this.http.post<string[]>('https://localhost:7258/api/Authentication/register')
  // }
 
 

  // public Authenticate = (route: string, user: User) => {
  //   return this.http.post<User>(this.createCompleteRoute(route, this.envUrl.urlAddress), user, this.generateHeaders());
  // }
  public getClaims = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
  public getOwners = (route: string) => {
    return this.http.get<User[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getOwner = (route: string) => {
    return this.http.get<User>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  // public createOwner = (route: string, owner: OwnerForCreation) => {
  //   return this.http.post<User>(this.createCompleteRoute(route, this.envUrl.urlAddress), owner, this.generateHeaders());
  // }

  // public updateOwner = (route: string, owner: OwnerForUpdate) => {
  //   return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), owner, this.generateHeaders());
  // }

  public deleteOwner = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }
}
