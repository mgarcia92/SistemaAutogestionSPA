import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { LoginServiceService } from '../login-service/login-service.service';

@Injectable()
export class AuthenticationGuard implements CanActivate {
  private user: any;
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

     return this.validateSession()
      .then((response) => {
          if(!response){
            this.router.navigate(['/login'])
          }
          return response;
      })
      .catch((err) => {
        console.log(err)
        return false;
      })
  }

  constructor(private authService: LoginServiceService, private router: Router) {}

  validateSession(): Promise<boolean> {
    this.user = this.authService.getUserId();
   return this.authService.sessionStatus(this.user)
                          .toPromise()
                          .then((response:any) => {
                                if(response.data.session){
                                  return true
                                }else{
                                  return false;
                                }
                          }).catch((err) => {
                              return false;
                          })
                          }
}
