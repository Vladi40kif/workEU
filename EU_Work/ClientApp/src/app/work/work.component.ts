import { Component, OnInit } from '@angular/core';
import { WorkDataService } from '../services/work-data.service';
import { FormGroup} from '@angular/forms';
@Component({
  selector: 'app-work',
  templateUrl: './work.component.html',
  styleUrls: ['./work.component.css']
})
export class WorkComponent implements OnInit {

  constructor(public service: WorkDataService) { }

  ngOnInit(): void {
  }

}
