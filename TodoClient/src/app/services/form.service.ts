import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  apiUrl = 'http://localhost:5000/api/tasks/sendTask';
  constructor(private http: HttpClient) { }

  sendTask(formData: any)
  {
    console.log("serwis działa")
    return this.http.post(this.apiUrl, formData)
  }
}
