import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'freela-ranking',
  templateUrl: './freela-ranking.component.html',
  styleUrls: ['./freela-ranking.component.css']
})
export class FreelaRankingComponent implements OnInit {

  link : string = '../../../assets/images/freela-ranking-icons/';
  @Input() freelaRanking? : number;
  ranking : string =  "Amigavel";
  constructor() { }

  ngOnInit(): void {
    if(this.freelaRanking == 1)
      this.ranking = "Amigavel";
    if(this.freelaRanking == 2)
    this.ranking = "Veterano";
    if(this.freelaRanking == 3)
    this.ranking = "Qualificado";

    this.link = this.link + this.ranking + ".svg";
  }

}
