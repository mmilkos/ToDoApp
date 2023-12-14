import { Component, OnInit } from '@angular/core';
import { FormService } from '../services/form.service';
import { FormModelDto } from './form.model';
import { RefreshService } from '../services/refresh.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  model: FormModelDto = {
    Name: '',
    Description: ''
  };

  constructor(private formService: FormService, private refreshService: RefreshService) {}

  ngOnInit(): void {}

  showModel() {
    console.log(this.model);
  }

  sendTask() {
    return this.formService.sendTask(this.model).subscribe({
      next: response => {
        this.refreshService.refresh();
        console.log(response);
        
      },
      error: error => console.error()
    });
  }
}