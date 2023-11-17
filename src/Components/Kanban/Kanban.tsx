import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Projet } from '../../Models/ProjetModel';
import '../../Styles/Kanban.css';
import { Tache } from '../../Models/TacheModel';
import Column from './KanbanColumn';
import { Statut } from '../../Models/StatutModel';
import { Console } from 'console';


const Kanban: React.FC<{ projet: Projet }> = ({ projet }) => {
    
    const tasks :Tache[]= projet.taches ;
    const [taches, setTasks] = useState<Tache[]>(tasks);
    console.log("kanban taches");
    console.log(taches);

    const statuts :Statut[]= projet.idStatuts;
    const [Statuts, setStatuts] = useState<Statut[]>(statuts);

    console.log("kanban satut");
    console.log(Statuts);

    return (
      <div className="kanban-board">
      {Statuts.map((statut, index) => {
        
        const filteredTasks = taches.filter((task) => task.idStatut === statut.idStatut);

        if (filteredTasks.length > 0) {
          return <Column key={index} status={statut} tasks={filteredTasks} />;
        }else{
          return <Column key={index} status={statut} tasks={[]} />;
        }

      })}
      </div>
 
  );
};

export default Kanban;
