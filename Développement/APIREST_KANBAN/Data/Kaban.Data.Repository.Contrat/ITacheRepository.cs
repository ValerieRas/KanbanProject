using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository.Contrat
{
    public interface ITacheRepository
    {

        /// <summary>
        /// Créer un tache dans un projet
        /// </summary>
        /// <param name="NewTache"></param>
        /// <returns></returns>
        Task<Tache> CreerTache(Tache NewTache);

        /// <summary>
        /// Supprimer une tache d'un projet
        /// </summary>
        /// <param name="supprTache"></param>
        /// <returns></returns>
        Task<Tache> SupprimerTache(Tache supprTache);


        /// <summary>
        /// Modifier une tache
        /// </summary>
        /// <param name="modifierTache"></param>
        /// <returns></returns>
        Task<Tache> ModifierTache(Tache modifierTache);

        /// <summary>
        /// Sélectionner une tâche avec son ID
        /// </summary>
        /// <param name="idTache"></param>
        /// <returns></returns>
        Task<Tache> SelecAvecIdTache(int idTache);

        /// <summary>
        /// Sélectionner toutes les tâches d'un projet
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        Task<List<Tache>> SelecAvecIdProjet(int idProjet);

        /// <summary>
        /// Sélectionner toutes les taches avec un statut spécifique
        /// </summary>
        /// <param name="idStatut"></param>
        /// <returns></returns>
        Task<List<Tache>> SelecAvecIdStatut(int idStatut);

        /// <summary>
        /// Sélectionner toutes les taches d'un utilisateur
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <returns></returns>
        Task<List<Tache>> SelecAvecIdUtilisateur(int idUtilisateur);




    }
}
