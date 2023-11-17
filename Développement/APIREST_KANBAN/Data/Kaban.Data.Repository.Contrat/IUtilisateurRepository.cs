using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository.Contrat
{

    public interface IUtilisateurRepository
    {

        /// <summary>
        /// Créer un utilisateur
        /// </summary>
        /// <param name="NewUtilisateur"></param>
        /// <returns></returns>
        Task<Utilisateur> CreerUtilisateur(Utilisateur NewUtilisateur);

        /// <summary>
        /// Supprimer un utilisateur
        /// </summary>
        /// <param name="supprUtilisateur"></param>
        /// <returns></returns>
        Task<Utilisateur> SupprimerUtilisateur(Utilisateur supprUtilisateur);

        /// <summary>
        /// Lister tous les utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Utilisateur>> SelecUtilisateur();

        /// <summary>
        /// Modifier un Utilisateur
        /// </summary>
        /// <param name="modifierUtilisateur"></param>
        /// <returns></returns>
        Task<Utilisateur> ModifierUtilisateur(Utilisateur modifierUtilisateur);

        /// <summary>
        /// sélectionner un utilisateur avec son ID 
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <returns></returns>
        Task<Utilisateur> SelecAvecIdUtilisateur(int idUtilisateur);


        /// <summary>
        /// sélectionner une liste d'utilisateur d'un projet
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        Task<List<Utilisateur>> SelecAvecIdProjetAsync(int idProjet);
    }
}
