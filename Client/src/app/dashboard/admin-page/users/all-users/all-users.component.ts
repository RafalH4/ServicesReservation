import { Component, OnInit } from '@angular/core';
import { ProvidersService } from 'src/app/services/providers.service';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit {

  users: any[];
  constructor(private _providersService: ProvidersService) { }

  ngOnInit(): void {
    this._providersService.getProviders().subscribe(resp => {
      this.users = resp;
      console.log(resp)
    })
  }

}
