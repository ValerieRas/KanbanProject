import React, { useState, useEffect } from 'react';
import '../Styles/SideMenuStyle.css'; 
import { Projet} from '../Models/ProjetModel';
import { getProjetsUtilisateur } from '../Services/ProjetService';
import { Link } from 'react-router-dom';


const YourComponent: React.FC = () => {
  const [projects, setProjects] = useState<Projet[]>([]);

  useEffect(() => {
      /*Appele APi pour les projets*/ 
      const fetchProjets = async () => {

        try {
  
          const response = await getProjetsUtilisateur(1);

          console.log(response.data);

          const ApiProjet= response.data;

          setProjects(ApiProjet);
  
        } catch (error) {
  
          console.error('Error fetching projets:', error);
  
        }
      };
  
      fetchProjets();

  }, []);

  const toggleProjectList = () => {
    const projectList = document.querySelector('.project-list');
    if (projectList) {
      projectList.classList.toggle('show');
    }
  };

  const handleClick = () => {
    // Reload the page when the link is clicked
    window.location.reload();
  };

  return (
    <aside className="side-menu">
      <nav>
        <ul>
        <Link to="/NouveauProjet">
          <li>Nouveau Projet</li>
        </Link>
          <li onClick={toggleProjectList}>Mes projets</li>
            <ul className="project-list">
              {projects.map((project: Projet, index) => (
                 <button onClick={handleClick}>
                <li className="nested-list" key={index}>
                  <Link to={`/Projet/${project.idProjet}`}>{project.nomProjet}</Link>
                </li>
                </button>
              ))}
            </ul>
          <Link to="/Utilisateur">
          <li>Mes tâches</li>
          </Link>
        </ul>
      </nav>
    </aside>
  );
}

export default YourComponent;
