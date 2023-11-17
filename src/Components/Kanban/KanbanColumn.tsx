import React,{useState} from 'react';
import DraggableCard from './KanbanCard';
import { useDrop} from 'react-dnd';
import '../../Styles/KanbanColumn.css';
import { Tache } from '../../Models/TacheModel';
import { Statut } from '../../Models/StatutModel';




const Column: React.FC<{status:Statut, tasks:Tache[]}> = ({ status, tasks }) => {

    console.log("colonne satut");
    console.log(status);

    const [taches, setTasks] = useState<Tache[]>([]);

    const [{ isOver }, drop] = useDrop({
        accept: 'CARD',
        drop: (item: { id: number; type: string }) => {
            const updatedTasks = tasks.map((task) => {
                if (parseInt(task.idTache) == item.id) {
                  return { ...task, idStatut: status.idStatut };
                }
                return task;
              });
        
              setTasks(updatedTasks);
        },
        collect: (monitor) => ({
          isOver: !!monitor.isOver(),
        }),
      });

  return (

    <div ref={drop} className={`column ${isOver ? 'column-over' : ''}`}>
      <h2>{status.descriptionStatus}</h2>
      {tasks.map((task) => (
        <DraggableCard key={task.idTache} task={task} />
      ))}
    </div>

  );
};

  export default Column;