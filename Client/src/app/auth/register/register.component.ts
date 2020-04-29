import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup

  constructor(private fb: FormBuilder,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  register(){
    return this.authService.registerClient(this.form.value).subscribe(resp =>{
      console.log(resp)
    })
  }

  registerAsAdmin(){
    return this.authService.registerAdmin(this.form.value).subscribe(resp =>{
      console.log(resp)
    })
  }
  isAdmin():boolean
  {
    return this.authService.hasRole("admin");
  }

}
