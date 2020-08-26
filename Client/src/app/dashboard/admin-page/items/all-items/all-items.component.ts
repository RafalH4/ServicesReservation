import { Component, OnInit } from '@angular/core';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-all-items',
  templateUrl: './all-items.component.html',
  styleUrls: ['./all-items.component.scss']
})
export class AllItemsComponent implements OnInit {

  items: any[]
  constructor(private _itemService: ItemService) { }

  ngOnInit(): void {
    this._itemService.getItems().subscribe(resp =>{
      this.items = resp;
      console.log(this.items)
    })
  }

  onDeleteItem(id) {
    console.log("Deleted "+id)
  }

}
