import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { first } from "rxjs/operators";
import { NgForm } from "@angular/forms";
import { AuthenticationService } from "../../_services";

import { User } from "../../_models/user";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  loading = false;
  submitted = false;
  error = "";
  userModel: User = {
    id: null,
    email: "",
    password: "",
    firstName: "",
    lastName: "",
    role: null,
    token: null,
    status: null,
  };

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    // redirect to home if already logged in
    // if (this.authenticationService.currentUser) {
    //   this.router.navigate(["/"]);
    // }
  }

  ngOnInit() {
    
  }

  onSubmit() {
    this.submitted = true;
    this.loading = true;
    this.authenticationService
      .login(this.userModel.email, this.userModel.password)
      .pipe(first())
      .subscribe({
        next: () => {
          // get return url from query parameters or default to home page
          const returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/";
          this.router.navigateByUrl(returnUrl);
        },
        error: (error) => {
          this.error = error;
          this.loading = false;
        },
      });
  }
}
