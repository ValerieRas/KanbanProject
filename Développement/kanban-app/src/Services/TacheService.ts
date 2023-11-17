import axiosinstance from '../AppConfig/AxiosConfig';
import {Tache } from '../Models/TacheModel';


export const getTAcheProjet = (idProjet: number) => {
  return axiosinstance.get<Tache>(`/api/v1?idUser=${idProjet}`);
};

export const getTAcheStatut = (idStatut: number) => {
    return axiosinstance.get<Tache>(`/api/v1?idUser=${idStatut}`);
  };


  export const getTAcheUtilisateur = (idUtilisateur: number) => {
    return axiosinstance.get<Tache>(`/api/v1?idUser=${idUtilisateur}`);
  };

  export const updateTache = (idTache: number) => {
    return axiosinstance.get<Tache>(`/api/v1?idUser=${idTache}`);
  };