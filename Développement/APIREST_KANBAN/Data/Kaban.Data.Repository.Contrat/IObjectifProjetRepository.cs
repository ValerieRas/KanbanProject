using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository.Contrat
{
    public interface IObjectifProjetRepository
    {
        /// <summary>
        ///  Créer un objectif pour un projet
        /// </summary>
        /// <param name="NewObjectifProjet"></param>
        /// <returns></returns>
        Task<ObjectifProjet> CreerObjectifProjet(ObjectifProjet NewObjectifProjet);


        /// <summary>
        /// Supprimer un objectif d'un projet
        /// </summary>
        /// <param name="supprObjectifProjet"></param>
        /// <returns></returns>
        Task<ObjectifProjet> SupprimerObjectifProjet(ObjectifProjet supprObjectifProjet);


        /// <summary>
        /// Modifier une un objectif d'un projet
        /// </summary>
        /// <param name="modifierObjectifProjet"></param>
        /// <returns></returns>
        Task<ObjectifProjet> ModifierObjectifProjet(ObjectifProjet modifierObjectifProjet);


        /// <summary>
        /// Liste tous les objectifs d'un projet
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        Task<List<ObjectifProjet>> SelecAvecIdProjet(int idProjet);

        /// <summary>
        /// Liste un objectif projet avec son id
        /// </summary>
        /// <param name="idObjectifProjet"></param>
        /// <returns></returns>
        Task<ObjectifProjet> SelecAvecIdObjectifProjet(int idObjectifProjet);
    }
}
