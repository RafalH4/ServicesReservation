import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-new-service-item',
  templateUrl: './new-service-item.component.html',
  styleUrls: ['./new-service-item.component.scss']
})
export class NewServiceItemComponent implements OnInit {

  form: FormGroup;
  FormData = new FormData()

  constructor(private fb: FormBuilder, private itemService: ItemService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      serviceName: ['', Validators.required],
      durationInMinutes: ['', Validators.required],
      // price: ['', Validators.required]
    })
  }

  addService(){
    this.itemService.addItem(this.form.value).subscribe(resp=>{
      console.log(resp)
    })
  }

}
