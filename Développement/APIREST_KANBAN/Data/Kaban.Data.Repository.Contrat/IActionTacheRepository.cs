using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository.Contrat
{
    public interface IActionTacheRepository
    {
        /// <summary>
        /// Créer une action pour une tâche
        /// </summary>
        /// <param name="NewActiontache"></param>
        /// <returns></returns>
        Task<ActionTache> CreerActionTache(ActionTache NewActiontache);

        /// <summary>
        /// Supprime une action d'une tâche
        /// </summary>
        /// <param name="supprActionTache"></param>
        /// <returns></returns>
       Task<ActionTache> SupprimerActionTache(ActionTache supprActionTache);


        /// <summary>
        /// Liste toutes les actions d'une tâche spécifique
        /// </summary>
        /// <param name="idTache"></param>
        /// <returns></returns>
       Task<List<ActionTache>> SelecAvecIdtache(int idTache);

        /// <summary>
        /// Modifier une action d'une tâche
        /// </summary>
        /// <param name="modifierActiontache"></param>
        /// <returns></returns>
        Task<ActionTache> ModifierActiontache(ActionTache modifierActiontache);

        /// <summary>
        /// Sélectionner une action d'une tache
        /// </summary>
        /// <param name="idActionTache"></param>
        /// <returns></returns>
        Task<ActionTache> SelecAvecIdActiontache(int idActionTache);
    }


}
