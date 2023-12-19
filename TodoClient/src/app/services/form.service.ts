import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  apiUrl = 'http://localhost:5000/api/tasks/sendTask';
  httpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  sendTask(formData : any)
  {
    console.log("Wysyłam post: ")
    return this.http.post(this.apiUrl, formData)
  }
}
