import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { CrudService } from '../services/crud.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
  @Input() id!: number;
  @Input() name!: string;
  @Input() desc!: string;


  constructor(private crud: CrudService) {}

  Delete(){
    
    this.crud.deleteTask(this.id).subscribe(
      response => {
        location.reload();
        console.log("Deleted")
      },
      error => {console.error(error)}
    )

  }
}