import { RegisterService } from './../../services/register.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AuthService } from 'src/services/auth.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  validateForm!: FormGroup;
  
  constructor(private fb: FormBuilder, private registerService: RegisterService, private notification: NzNotificationService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      firstName: [null, [Validators.required, Validators.maxLength(32), Validators.pattern('^[a-zA-Z ]*$')]],
      lastName: [null, [Validators.required, Validators.maxLength(32), Validators.pattern('^[a-zA-Z ]*$')]],
      studentId: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(8)]],
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
      // Other fields here
    });
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls.password.value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      if (this.validateForm.controls.hasOwnProperty(i)) {
        this.validateForm.controls[i].markAsDirty();
       this.validateForm.controls[i].updateValueAndValidity();
      }
    }
    this.registerService.register(this.validateForm).subscribe( 
      (ret) => {
        if (ret === true) {
        console.log(ret);
        this.notification.create(
          'success',
          'Registration Successful!',
          'Thank you for registering!'
        ); 
        // navigate to recommendations page
      } else {
        this.notification.create(
          'error',
          'Registration Failed',
          'Unfortunately, registration was not accepted. Please check all fields are correct.'
        );
      }
      }, 
      (err) => {
        this.notification.create(
          'error',
          'Registration Failed',
          'An error occured. Please try again'
        );
        console.error(err);  
      }
    );
  }

}
