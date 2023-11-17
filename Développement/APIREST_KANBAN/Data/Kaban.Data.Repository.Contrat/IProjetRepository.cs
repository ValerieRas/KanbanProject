using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository.Contrat
{
    public interface IProjetRepository
    {
        /// <summary>
        ///  Créer un projet
        /// </summary>
        /// <param name="NewProjet"></param>
        /// <returns></returns>
        Task<Projet> CreerProjet(Projet NewProjet);

        /// <summary>
        /// Supprimer un projet
        /// </summary>
        /// <param name="supprProjet"></param>
        /// <returns></returns>
        Task<Projet> SupprimerProjet(Projet supprProjet);

        /// <summary>
        /// Modifier un projet
        /// </summary>
        /// <param name="modifierProjet"></param>
        /// <returns></returns>
        Task<Projet> ModifierProjet(Projet modifierProjet);

        /// <summary>
        /// Sélectionner un projet spécifique
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        Task<Projet> SelecAvecIdProjet(int idProjet);


        /// <summary>
        /// sélectionner une liste des projets d'un utilisateur
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <returns></returns>
        Task<List<Projet>> SelecAvecIdUtilisateur(int idUtilisateur);


    }
}
