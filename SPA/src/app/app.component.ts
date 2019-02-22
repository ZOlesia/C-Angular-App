import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  jwtHelper = new JwtHelperService();

  // decoding the token in the main component (app.comp) =>
  //  because we have to populate our decoded token =>
  //  not only in the login() method in authService.service.ts =>
  // if only to decode in authService.service.ts, after refreshing the page the decoded token will disappear
  // and the username will not be displayed

  constructor(private authService: AuthService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }
}



