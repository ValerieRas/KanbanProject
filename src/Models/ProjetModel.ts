import {Utilisateur} from './UtilisateurModel';
import {Tache} from './TacheModel';
import {Statut} from './StatutModel';

export interface Projet {
    idProjet: string;
    nomProjet: string;
    dateDebut: Date;
    dateFin: Date | null;
    objectifProjets:ObjectifProjet[];
    taches: Tache[];
    idStatuts:Statut[];
    idUtilisateurs: Utilisateur[];
  };
  

export interface ObjectifProjet {
  idObjectifProjet: string; 
  descriptionObjectif:string;
  complete: boolean; 
} 

