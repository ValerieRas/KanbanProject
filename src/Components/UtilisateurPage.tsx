import React, {useState,useEffect} from 'react';
import { Link } from 'react-router-dom';
import '../Styles/UtilisateurPage.css';
import ProjetMiniature from '../Components/ProjetMiniature';
import {Projet} from '../Models/ProjetModel';
import {getProjetsUtilisateur} from '../Services/ProjetService';

const UtilisateurPage: React.FC = () => {

    const [projects, setProjects] = useState<Projet[]>([]);

  useEffect(() => {
      /*Appele APi pour les projets*/ 
      const fetchProjets = async () => {

        try {
  
          const response = await getProjetsUtilisateur(1);

          const ApiProjet= response.data;

          setProjects(ApiProjet);
  
        } catch (error) {
  
          console.error('Error fetching projets:', error);
  
        }
      };
  
      fetchProjets();

  }, []);


    return (
        <div className="Projetcontainer">
          {/*}   {projects.map((project: Projet, index) => (
                <Link to="/Projet">
                    <ProjetMiniature key={index}/>
                 </Link>
          ))}*/}

        </div>
    );
  };
  
  export default UtilisateurPage;