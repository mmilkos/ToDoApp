import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { CrudService } from '../services/crud.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent 
{
  @Input() id!: number;
  @Input() name!: string;
  @Input() desc!: string;
  @Input() status!: boolean;


  constructor(private crud: CrudService) {}

  Delete()
  {
    this.crud.deleteTask(this.id).subscribe(
      {
        error: error => console.error(error)
      }
    )
  }

  Update()
  {
    this.crud.updateTaskStatus(this.id).subscribe(
      {
        error: error => console.error(error)
      }
    )
  }
  
}
