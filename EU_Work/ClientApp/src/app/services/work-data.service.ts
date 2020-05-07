import { Injectable, OnInit } from '@angular/core';
import { WorkModel } from './work-model.service';
import { FormArray, FormControl, FormBuilder } from '@angular/forms';
import { HttpClient} from '@angular/common/http';
//import { getBaseUrl } from 'src/main';

@Injectable({
  providedIn: 'root'
})
export class WorkDataService implements OnInit {
  
  constructor(public model: WorkModel,
      private formBuilder: FormBuilder,
      private httpClient: HttpClient) { }
  
  ngOnInit(){}

  public addEducations() {// DRY???????
    (this.model.Form.controls['educations'] as FormArray).push( this.formBuilder.group({
      Institution: '',
      Faculty: '',
      Form: '',
      Start: '',
      Stop: '',
    }) );

  }

  public send(){
    //let form = JSON.stringify(this.model.Form.value);
    console.log(this.model.Form.value);
    return this.httpClient.post('https://localhost:5001/api/Email',this.model.Form.value).subscribe(x=>{
      console.log("zbs " + x );
    },err=>{
      console.log("pzd");
      console.log(err);
    }
    );
  }
  public rm(ind){
    (this.model.Form.controls['educations'] as FormArray).removeAt(ind);
  }

}
