import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, tap,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


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
    return this.http.post(this.apiUrl, formData).pipe(
      catchError(this.handleError)
    );
  }


  updateTaskStatus(id : number)
  {
    return this.http.put(this.apiUrl + id, null).pipe(
      catchError(this.handleError)
    )
  }


  deleteTask(id : number): Observable<any>
  {
    return this.http.delete(this.apiUrl + id).pipe(
      catchError(this.handleError)
    );
  }


  addTaskToCollection(task : any)
  {
    this.tasks.push(task);
  }

  
  getTasks()
  {
    return this.tasks;
  }


  private handleError(error: HttpErrorResponse) 
  {
    if (error.status === 404) 
    {
      alert('Task not found');
    } 
    if (error.status == 400) 
    {
      alert("The field Name must have minimum length of 2")
    }

    return throwError(error);
  }
}

