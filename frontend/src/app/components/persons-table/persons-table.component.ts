import { Component, OnInit } from '@angular/core';
import {DataProviderService} from "../../services/data-provider.service";

@Component({
  selector: 'app-persons-table',
  templateUrl: './persons-table.component.html',
  styleUrls: ['./persons-table.component.scss']
})
export class PersonsTableComponent implements OnInit {

  constructor(public service: DataProviderService) { }

  ngOnInit(): void {
  }

}
