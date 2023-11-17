import React from 'react';
import { useDrag } from 'react-dnd';
import '../../Styles/Kanbancard.css';
import { Tache } from '../../Models/TacheModel';
import { format } from 'date-fns';

const DraggableCard: React.FC<{task:Tache}> = ({ task }) => {

  const [{ isDragging }, drag] = useDrag({
    type: 'CARD',
    item: { id: task.idTache, type: 'CARD' },
    collect: (monitor) => {
      console.log('Item is dragging:', monitor.getItem()); // Log the item being dragged
      return {
        isDragging: !!monitor.isDragging(),
      };
    },
  });

  return (
    <div ref={drag} className={`card ${isDragging ? 'card-dragging' : ''}`}>
      <h3>{task.titreTache}</h3>
      <p>{task.descriptionTache}</p>
      <p>Date limite:{task.dateLimite}</p>
    </div>
  );
};

export default DraggableCard;