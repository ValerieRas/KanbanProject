import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Projet } from '../Models/ProjetModel';
import { getProjetsAvecID } from '../Services/ProjetService';
import { useParams } from 'react-router-dom';
import '../Styles/ProjetPage.css';
import { Utilisateur } from '../Models/UtilisateurModel';
import { ObjectifProjet } from '../Models/ProjetModel';
import Kanban from './Kanban/Kanban';
import { format } from 'date-fns';



const ProjetPage: React.FC = () => {
  const [project, setProjects] = useState<Projet>();
  const [utilisateurs, setUtilisateurs] = useState<Utilisateur[]>([]);
  const [Objectifs, setObjectifs] = useState<ObjectifProjet[]>([]);

  const params = useParams();

  // Access the value directly
  const idProjet = params['idProjet'];

  const projectId: number | undefined = idProjet ? parseInt(idProjet, 10) : undefined

  useEffect(() => {
    /*Appele APi pour les projets*/
    const fetchProjets = async () => {

      try {

        if (projectId) {
          const response = await getProjetsAvecID(projectId);

          const ApiProjet = response.data;
          console.log(ApiProjet);

          const ApiUtilisateur : Utilisateur[]=response.data.idUtilisateurs;
          console.log(ApiUtilisateur);

          const ApiObjectif:ObjectifProjet[]=response.data.objectifProjets;
          console.log(ApiObjectif);

          setProjects(ApiProjet);
          setObjectifs(ApiObjectif);
          setUtilisateurs(ApiUtilisateur);


        }

      } catch (error) {

        console.error('Error fetching projets:', error);

      }
    };

    fetchProjets();

  }, []);
  return (
    <div className="Projetcontainer">
      <div className="ProjetDescription">
        <div className="first-row">
        {project && <h2>Nom projet: {project.nomProjet}</h2>}
        {project && <h3>Date début : {project.dateDebut.toString()}</h3>}
        {project && project.dateFin && <h3>Date fin : {project.dateFin.toString()}</h3>}
        </div>
        <div className="second-row">
        <h3>Objectifs:</h3>
          <ul>
          {Objectifs.map((Objectif: ObjectifProjet, userIndex) => (
            <li key={userIndex}>{Objectif.descriptionObjectif}</li>
          ))}
          </ul>

        </div>

        <div className="second-row">
        <h3>Membres d'équipes:</h3>
          <ul>
          {utilisateurs.map((user: Utilisateur, userIndex) => (
            <li key={userIndex}>{user.nom}{user.prenom}</li>
          ))}

          </ul>
        </div>
      </div>

      {project &&<Kanban projet={project}/>}
      
    </div>
  );
};

export default ProjetPage;