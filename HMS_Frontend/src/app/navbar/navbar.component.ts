import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{
  isCollapsed: boolean = false;
  isUserAuthenticated?: boolean;
constructor(private auth: AuthService, private route: Router){}
  
ngOnInit(): void {
 this.auth.authChanged.subscribe(res =>{
  this.isUserAuthenticated = res;
 })
}
public logout = () => {
  this.auth.logout();
  this.route.navigate(["/"]);
}
}
