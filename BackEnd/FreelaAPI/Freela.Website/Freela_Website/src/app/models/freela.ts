import { Company } from "./company";
import { UserProject } from "./userProject";

export interface Freela{
   id? : number;
   name : string;
   whatsapp : string;
   photourl : string;
   biography : string;
   area : string;
   price : string;
   curriculum : string;
   company : Company;
   userProject? : UserProject[];
}
