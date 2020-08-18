import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {

  constructor(private _userService: UserService) { }

  newUser = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    phoneNumber: new FormControl(''),
    password: new FormControl(''),
    password2: new FormControl(''),
    isAdmin: new FormControl('')
  })

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.newUser.value.isAdmin)
      this._userService.addAdmin(this.newUser.value).subscribe(
        data => console.log(data),
        err => console.log(err)
      )
      else
      this._userService.addClient(this.newUser.value).subscribe(
        data => console.log(data),
        err => console.log(err)
      )
  }


}
