import { Component, OnInit } from '@angular/core';
import { ProvidersService } from 'src/app/services/providers.service';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.scss']
})
export class ProvidersComponent implements OnInit {
  providers: any[]

  constructor(private _providersService : ProvidersService) { }

  ngOnInit(): void {
    this._providersService.getProviders().subscribe(resp =>{
      this.providers = resp;
      console.log(resp)
    })
  }

}
