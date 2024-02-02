import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/models/company';
import { Project } from 'src/app/models/project';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {

  public project : Project[] = [];

  constructor(private projectService : ProjectService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    ) { }

  ngOnInit(): void {
    this.getProject();
  }


  public getProject() : void{
    this.spinner.show();

    this.projectService.getProject().subscribe(
      response =>{
        this.project = response;
      },error => {
      console.log(error)
      this.spinner.hide();
      this.toastr.error('Erro ao salvar','Erro!')
    });
    setTimeout(() => {
      this.spinner.hide();
    }, 2000);

  }

}
