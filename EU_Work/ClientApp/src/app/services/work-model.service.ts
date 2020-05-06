import { FormGroup, Validators, FormControl, FormArray, FormBuilder, FormArrayName } from "@angular/forms";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class WorkModel{

    constructor(private formBuilder: FormBuilder){}

    public Form = new FormGroup({

        name: new FormControl('', [
            Validators.maxLength(50) 
        ]), 
        sname: new FormControl('', [
            Validators.maxLength(50)  
        ]),
        bd: new FormControl(),
        educations: new FormArray([this.formBuilder.group({
            Institution: '',
            Faculty: '',
            Form: '',
            Start: '',
            Stop: '',
        })
        ]),
        addres_official: new FormControl(''),
        phone: new FormControl('+380', [
            Validators.pattern('^\\+380\\d{3}\\d{2}\\d{2}\\d{2}$')
        ]),
        email: new FormControl('', [ 
            Validators.pattern('^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$') 
        ]),
        officilal_ukr_work_any_time: new FormControl(false),
        officilal_eu_work_any_time: new FormControl(false),
        officilal_ukr_work_now: new FormControl(false),
        officilal_eu_work_now: new FormControl(false),
        about: new FormControl(''),
        presonal_data_agree: new FormControl(false)
        
    }); 
}