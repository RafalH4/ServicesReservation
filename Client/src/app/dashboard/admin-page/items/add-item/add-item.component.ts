import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.scss']
})
export class AddItemComponent implements OnInit {

  constructor(private _itemService: ItemService) { }

  newItem = new FormGroup({
    serviceName: new FormControl(''),
    durationInMinutes: new FormControl('')
  })

  ngOnInit(): void {
  }

  onSubmit(){
    this._itemService.addItem(this.newItem.value).subscribe(
      data => console.log("Added"),
      err => console.log(err)
    )

  }

}
