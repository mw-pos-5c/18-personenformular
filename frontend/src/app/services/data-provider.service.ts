import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import PersonDto from "../models/PersonDto";

@Injectable({
  providedIn: 'root'
})
export class DataProviderService {

  constructor(private http: HttpClient) {
  }

  private url: string = "http://localhost:5000/api/Person"

  public persons: PersonDto[] = [];

  loadPersons() {
    this.http.get<PersonDto[]>(this.url).subscribe(value => {
      this.persons = value;
    })
  }


  savePerson(person: PersonDto) {
    this.http.post(this.url, person).subscribe(value => {
      alert(value);
      this.loadPersons();
    });

  }
}
