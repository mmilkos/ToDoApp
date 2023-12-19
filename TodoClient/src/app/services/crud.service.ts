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

  postTask(formData : any): Observable<any>{
    console.log(formData)
    return this.http.post(this.apiUrl + "sendTask", formData);
  }

  getAllTasks(): Observable<any>{
    return this.http.get<any[]>(this.apiUrl).pipe(
      tap((tasks: any[]) => {
        this.tasks = tasks;
      })
    );
  }

  deleteTask(id : number): Observable<any>{
    
    return this.http.delete(this.apiUrl + "deleteTask/" + id);
  }

  addTaskToCollection(task : any){
    this.tasks.push(task);
  }

  updateTaskStatus(){
    
  }
  

  getTasks(){
    return this.tasks;
  }
}