import { FormGroup, Validators, FormControl, FormArray, FormBuilder, FormArrayName } from "@angular/forms";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class WorkModel{

    constructor(private formBuilder: FormBuilder){}

    public Form = new FormGroup({

        name: new FormControl('', [
            Validators.minLength(4),
            Validators.maxLength(24) 
        ]), 
        sname: new FormControl('', [
            Validators.minLength(4),
            Validators.maxLength(24)  
        ]),
        educations: new FormArray([this.formBuilder.group({
            Institution: '',
            Faculty: '',
            Form: '',
            Start: '',
            Stop: '',
        })
        ]),
        addres_official: new FormControl(''),
        addres_actual: new FormControl(''),
        phone: new FormControl('', [
            //Validators.pattern('^(?:\+38)?(?:\(044\)[ .-]?[0-9]{3}[ .-]?[0-9]{2}[ .-]?[0-9]{2}|044[ .-]?[0-9]{3}[ .-]?[0-9]{2}[ .-]?[0-9]{2}|044[0-9]{7})$')
        ]),
        email: new FormControl('', [ 
            Validators.pattern('^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$') 
        ]),
        officilal_ukr_work_any_time: new FormControl(false),
        officilal_eu_work_any_time: new FormControl(false),
        officilal_ukr_work_now: new FormControl(false),
        officilal_eu_work_now: new FormControl(false),
        about: new FormControl('')
        
    }); 
}