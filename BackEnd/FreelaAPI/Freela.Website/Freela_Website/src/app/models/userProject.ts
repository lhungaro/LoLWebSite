import { Freela } from "./freela";
import { Project } from "./project";

export interface UserProject{
  UserId :  number;
  User : Freela;
  ProjectId :  number;
  Project : Project;
}
