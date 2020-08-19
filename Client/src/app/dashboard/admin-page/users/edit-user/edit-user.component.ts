import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss']
})
export class EditUserComponent implements OnInit {

  user: any
  id: any

  // editForm = new FormGroup({
  //   id: new FormControl([this.user.id]),
  //   firstName: new FormControl(''),
  //   lastName: new FormControl(''),
  //   email: new FormControl(''),
  //   phoneNumber: new FormControl(''),
  // })
  editForm = this._fb.group({
    id: [''],
    firstName: [''],
    lastName: [''],
    email: [''],
    phoneNumber: ['']
  })
  constructor(
    private _userService: UserService,
    private _route: ActivatedRoute,
    private _fb: FormBuilder) {
      this.id = this._route.snapshot.paramMap.get('id');
     }

  ngOnInit(): void {
    this._userService.getUser(this.id).subscribe(resp =>{
      this.user = resp;
      console.log("USER:")
      console.log(this.user);
      this.editForm.setValue({
        id: this.user.id,
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        email: this.user.email,
        phoneNumber: this.user.phoneNumber
      })
    })
  }
  onSubmit() {
    console.log('zatwierdzam');
    this._userService.updateUser(this.editForm.value).subscribe(
      data => console.log(data),
      err => console.log(err)
    )
  }


}
