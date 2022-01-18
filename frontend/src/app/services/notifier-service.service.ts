import { Injectable } from '@angular/core';
import {Observable, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NotifierServiceService {

  constructor() { }

  subject: Subject<number> = new Subject<number>();

  listen(): Observable<number> {
    return this.subject.asObservable();
  }

  notify(id: number): void {
    console.log("NotifierService::notify "+id);
    this.subject.next(id);
  }

}
