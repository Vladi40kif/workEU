import { Component, OnInit } from '@angular/core';
import { WorkDataService } from '../services/work-data.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-work',
  templateUrl: './work.component.html',
  styleUrls: ['./work.component.css']
})
export class WorkComponent implements OnInit {

  constructor(public service: WorkDataService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    
  }

  public Submit(){
    this.toastr.info("Не обновляйте сторінку","Відправлення...");
    this.service.send().subscribe(x=>{
      this.toastr.success("Ваша заявка успішно надіслана","Успіх!");  
      this.service.model.Form.reset();
    },err=>{
      console.log(err);
      this.toastr.error("Нажаль ваша форма не була надіслана. Обновіть сторінку та спробуйте ще раз.","Помилка!");  
    });
  }

}
