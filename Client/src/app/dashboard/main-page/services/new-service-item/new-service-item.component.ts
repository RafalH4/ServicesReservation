import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-new-service-item',
  templateUrl: './new-service-item.component.html',
  styleUrls: ['./new-service-item.component.scss']
})
export class NewServiceItemComponent implements OnInit {

  form: FormGroup;
  formData = new FormData()

  constructor(private fb: FormBuilder, 
    private itemService: ItemService, 
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      serviceName: ['', Validators.required],
      durationInMinutes: ['', Validators.required],
      // price: ['', Validators.required]
    })
  }

  addService(){
    this.itemService.addItem(this.form.value).subscribe(resp=>{
      this.router.navigate(["/admin/services"])
    })
  }
}
