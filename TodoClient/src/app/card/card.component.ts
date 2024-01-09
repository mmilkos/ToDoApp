import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { TasksService } from '../services/tasks.service';
import { AccountService } from '../services/account.service';
import { HttpHeaders } from '@angular/common/http';

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


  constructor(private Task: TasksService, private Account: AccountService) {}

  Delete()
  {
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.Account.currentUserSource.value?.token)
    this.Task.deleteTask(this.id, headers).subscribe(
    {
      next: () =>
      {
        location.reload();
      },
      error: error => console.error(error)
    }
    );
  }

  update()
  {
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.Account.currentUserSource.value?.token)
    this.Task.updateTaskStatus(this.id, headers).subscribe(
      {
        next: response => console.log(response),
        error: error => console.error(error)
      }
    )
  }
  
}
