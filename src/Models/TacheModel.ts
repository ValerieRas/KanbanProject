
export interface Tache {
  idTache:string;
  titreTache:string;
  descriptionTache:string;
  dateCreaction:string;
  dateLimite:string;
  actiontaches:ActionTache[];
  idProjet:string;
  idStatut:string;
  idUtilisateur:string;
} 

export interface ActionTache{
    idActiontache:string;
    descriptionActionTache:string;
    idTache:string;
    complete:boolean;
}