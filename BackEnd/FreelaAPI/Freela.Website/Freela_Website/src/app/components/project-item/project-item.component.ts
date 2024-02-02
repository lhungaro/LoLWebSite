import { Component, Input, OnInit } from '@angular/core';
import { Project } from 'src/app/models/project';

@Component({
  selector: 'app-project-item',
  templateUrl: './project-item.component.html',
  styleUrls: ['./project-item.component.css']
})
export class ProjectItemComponent implements OnInit {

  @Input() project?: Project;
  category? : string = "NodeJs";
  publishTime : number = 8;
  ranking : number = 0;
  constructor() { }

  ngOnInit(): void {
    this.ranking =  this.project?.ranking ?? 0;

  }

}
