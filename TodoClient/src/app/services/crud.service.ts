import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CrudService {

  tasks: any[] = [];
  apiUrl = "http://localhost:5000/api/tasks/";
  constructor(private http: HttpClient, ) { }


  getAllTasks(): Observable<any>
  {
    return this.http.get<any[]>(this.apiUrl).pipe(
      tap((tasks: any[]) => 
      {
        this.tasks = tasks;
      })
    );
  }


  postTask(formData : any): Observable<any>
  {
    return this.http.post(this.apiUrl, formData);
  }


  updateTaskStatus(id : number)
  {
    return this.http.put(this.apiUrl + id, null)
  }


  deleteTask(id : number): Observable<any>
  {
    return this.http.delete(this.apiUrl + id);
  }


  addTaskToCollection(task : any)
  {
    this.tasks.push(task);
  }

  
  getTasks()
  {
    return this.tasks;
  }
}
