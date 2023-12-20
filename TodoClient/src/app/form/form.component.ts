import { Component, OnInit } from '@angular/core';
import { FormModelDto } from './form.model';
import { CrudService } from '../services/crud.service';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent  {
  model : FormModelDto = {
    Name: "",
    Description: ""
  }


  constructor(private crud: CrudService) {}

  Submit()
  {
    this.crud.postTask(this.model).subscribe(
      response => 
      {
        this.crud.addTaskToCollection(response)
        this.model.Description = "";
        this.model.Name = "";
      },
      error => console.error(error)
    )
  }

}