import { Component, OnInit } from '@angular/core';
import { LoginServiceService } from '../services/login-service/login-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  username :string;
  constructor(private loginService: LoginServiceService,private router: Router) {
    this.username = this.loginService.getUserInfo().fichaNm;
   }

  ngOnInit() {
  }

  logout(){
    let user = this.loginService.getUserId();
    this.loginService.logout(user).toPromise()
    .then((response:any) => {
      if(response.data.session)
        this.router.navigate(['/login'])
      })
    .catch((err) => {
      console.log(err)
    });
  }

}
