import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-edit-service-item',
  templateUrl: './edit-service-item.component.html',
  styleUrls: ['./edit-service-item.component.scss']
})
export class EditServiceItemComponent implements OnInit {
  id: any
  itemToModify: any;
  form: FormGroup;
  tekst = 'asd'

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private itemService: ItemService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params.id
    this.itemService.get(this.id).subscribe(resp => {
      this.itemToModify=resp
      console.log(resp)
   })
   this.form = this.fb.group({
    //  id: [resp.id, Validators.required],
      serviceName: [this.tekst, Validators.required],
      durationInMinutes: ['', Validators.required],
    })
  }

  update(){
    console.log(this.form)
  }

}
