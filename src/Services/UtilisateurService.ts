import axiosinstance from '../AppConfig/AxiosConfig';
import {Utilisateur } from '../Models/UtilisateurModel';


export const getUtilisateurProjet = (idProjet: number) => {
  return axiosinstance.get<Utilisateur>(`/api/v1?idUser=${idProjet}`);
};

export const getUtilisateur = () => {
    return axiosinstance.get<Utilisateur[]>('/Utilisateur');
  };