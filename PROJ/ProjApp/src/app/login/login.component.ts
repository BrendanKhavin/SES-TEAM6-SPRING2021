import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {
  validateForm!: FormGroup;

  constructor(private fb: FormBuilder, private  authService: AuthService, private notification: NzNotificationService, private router: Router) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    });
  }

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      if (this.validateForm.controls.hasOwnProperty(i)) {
        this.validateForm.controls[i].markAsDirty();
        this.validateForm.controls[i].updateValueAndValidity();
      }
    }
    this.authService.login(this.validateForm).subscribe(
      (ret) => {
       if (ret) {
         this.notification.create(
          'success',
          'Login Successful!',
          'Thank you for using Subjects "R" Us')
        this.router.navigate(['recommendation']);
       } else {
         this.notification.create(
          'error',
          'Login Failed',
          'Please check your details.'
         )
       }
      }
    )
  }

}
