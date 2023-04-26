import { Injectable } from '@angular/core';
import { development } from './../../environments/development'
@Injectable({
  providedIn: 'root'
})
export class EnvironmentUrlService {
  urlAddress: string = development.baseUrl;
  constructor() { }
}
