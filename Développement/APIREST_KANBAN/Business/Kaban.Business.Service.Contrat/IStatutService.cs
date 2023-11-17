using Kaban.Business.DTO.StatutDTO;
using Kaban.Business.Mapper.StatutMap;
using Kaban.Data.Repository.Contrat;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service.Contrat
{
    public interface IStatutService
    {
        /// <summary>
        /// Affiche le le Statut selon son indentifiant
        /// </summary>
        /// <param name="IdStatut">Identifiant du Statut qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireStatutDTO> AfficherStatutAvecIdStatutAsync(int IdStatut);

        /// <summary>
        /// Permet de créer un Statut dans la table Statut
        /// </summary>
        /// <param name="StatutDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireStatutDTO> CreerStatutAsync(CreerStatutDTO StatutDTO);



        /// <summary>
        /// Méthode pour supprimer un Statut de la base de donnée
        /// </summary>
        /// <param name="IdStatut"> identifiant du Statut dans la tbale Statut</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireStatutDTO> SupprimerStatutAsync(int IdStatut);


        /// <summary>
        /// Modifier les informations du Statut
        /// </summary>
        /// <param name="IdStatut">Le Statut à modifier</param>
        /// <param name="StatutDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireStatutDTO> ModifierStatutAsync(int IdStatut, ModifierStatutDTO StatutDTO);



    }
}
