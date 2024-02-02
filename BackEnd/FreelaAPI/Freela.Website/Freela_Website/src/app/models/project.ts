import { Company } from "./company";
import { UserProject } from "./userProject";

export interface Project{
    id:number ;
    title:string ;
    createdate:Date;
    proposes:number ;
    description:string ;
    status:number ;
    ranking:number ;
    area:string ;
    valuetopay:string;
    categories:string;
    contaxt:string;
    company:Company ;
    userproject?: UserProject[] ;
}
