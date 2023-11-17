import axiosinstance from '../AppConfig/AxiosConfig';
import { Projet } from '../Models/ProjetModel';


export const getProjetsUtilisateur = (idUtilisateur: number) => {
  return axiosinstance.get<Projet[]>(`/Projet/Utilisateur/${idUtilisateur}`);
};

export const getProjetsAvecID = (idProjet: number) => {
    return axiosinstance.get<Projet>(`/Projet/${idProjet}`);
  };

export const PostProjets = (Projet: Projet) => {
    return axiosinstance.post(`/Projet/`,Projet);
};