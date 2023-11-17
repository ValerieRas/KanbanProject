using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository.Contrat
{
    public interface IStatutRepository
    {
        /// <summary>
        /// Créer un statut
        /// </summary>
        /// <param name="NewStatut"></param>
        /// <returns></returns>
        Task<Statut> CreerStatut(Statut NewStatut);

        /// <summary>
        /// Supprimer un statut
        /// </summary>
        /// <param name="supprStatut"></param>
        /// <returns></returns>
        Task<Statut> SupprimerStatut(Statut supprStatut);

        /// <summary>
        /// Lister tous les statuts
        /// </summary>
        /// <returns></returns>
        Task<List<Statut>> SelecStatut();

        /// <summary>
        /// Modifier un statut
        /// </summary>
        /// <param name="modifierStatut"></param>
        /// <returns></returns>
        Task<Statut> ModifierStatut(Statut modifierStatut);

        /// <summary>
        /// Sélectionner un statut avec ID
        /// </summary>
        /// <param name="idStatut"></param>
        /// <returns></returns>
        Task<Statut> SelecAvecIdStatut(int idStatut);
    }
}
