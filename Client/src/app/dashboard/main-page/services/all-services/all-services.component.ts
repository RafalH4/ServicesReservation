import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-all-services',
  templateUrl: './all-services.component.html',
  styleUrls: ['./all-services.component.scss']
})
export class AllServicesComponent implements OnInit {
  items = [];

  constructor(private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getItems().subscribe(resp =>{
      this.items = resp;
      console.log(resp)
    })
  }

  remove(id){
    this.itemService.remove(id).subscribe(resp =>{
      console.log(resp)
    })
  }

}
