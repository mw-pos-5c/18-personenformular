import {Component, Input, OnInit} from '@angular/core';
import PersonDto from "../../models/PersonDto";
import {DataProviderService} from "../../services/data-provider.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.scss']
})
export class EditPersonComponent implements OnInit {

  constructor(private service: DataProviderService, private builder: FormBuilder) {
    this.form = builder.group({
      firstname: ['', [Validators.required, Validators.minLength(3), Validators.pattern(/^[A-Z]/)]],
      lastname: ['', [Validators.required]],
      tel: ['', [Validators.required, Validators.pattern(/^\+\d{2}\s\(\d{2}\)\s\d{4,6}$/)]],
      born: ['', [Validators.required, Validators.pattern(/^\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}$/)]],
      address: ['', [Validators.required, Validators.pattern(/^(\w)-(\d{4})\s(\w+),\s(\w+)\s(\d)$/)]]
    })
  }

  public form: FormGroup;

  ngOnInit(): void {
  }

  save() {
    this.service.savePerson(this.form.value);
  }
}
