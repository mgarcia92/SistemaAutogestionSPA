import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { LoginServiceService } from '../services/login-service/login-service.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
   username: string;
   password: string ;
   message = '';
   loading = false;
   logon = false;
   private alert: ElementRef;
   @ViewChild('alert') set content(content: ElementRef) {
      if(this.alert  == undefined)
            this.alert = content;
 };
  constructor(private loginService: LoginServiceService, private router: Router) {

   }

  ngOnInit() {
  }

 public loginUser(form) {
    this.message = '';
    this.username = form.value.username;
    this.password = form.value.password;

    if (this.username === '') {
        this.message = "Ingrese un Usuario para continuar";
        return;
    }

    if (this.password === '') {
        this.message = "Ingrese un Password para continuar";
        return;
    }

    this.loading = true;

    this.loginService.logonUser(this.username,this.password).toPromise()
    .then((result: any) => {
      this.loading = false;
     // this.toastr.success('Hello world!', 'Toastr fun!');
      if(result.data.length > 0) {
        this.logon = true;
        this.message = "Usuario Autorizado.";
        sessionStorage.clear();
        sessionStorage.setItem("userId",JSON.stringify(result.data[0]));
        this.router.navigate(['/home']);
      }else{
        this.message =  result.message;
      }
    }).catch((err) =>{
      console.log(err)
      this.loading = false;
    })
  }

}
