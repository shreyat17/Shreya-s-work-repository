import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ILogin } from '../register-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  loginObj = {} as ILogin;
  subscription!: Subscription;
  returnUrl!: string | null;

  constructor(
    private _authenticationService: AuthenticationService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    //this.loginObj = { userName: 'padma@gmail.com', password: 'Padma@123' }
    this.returnUrl = this.activatedRoute.snapshot.queryParamMap.get("returnUrl");
  }

  public login(f: NgForm) {
    this.subscription = this._authenticationService.postData("Accounts/LoginUser", this.loginObj).subscribe({
      next: (data: any) => {
        if (data.statusCode == 200 && data.data != null) {
          console.log(data);
          localStorage.setItem("token", data.data);
          if (this.returnUrl)
            this.router.navigate([this.returnUrl]);
          else
            this.router.navigate(["/admin/employee"]);
        }
        else {
          console.log(data.message);
        }
      },
      error: reason => console.log(reason)
    });
  }

  ngOnDestroy(): void {
    if (this.subscription)
      this.subscription.unsubscribe();
  }
}
