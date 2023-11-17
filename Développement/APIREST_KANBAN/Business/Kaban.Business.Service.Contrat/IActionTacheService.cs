using Kaban.Business.DTO.ActionTacheDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service.Contrat
{
    public interface IActionTacheService
    {
        /// <summary>
        /// Affiche le lcient selon son indentifiant
        /// </summary>
        /// <param name="IdActionTache">Identifiant du ActionTache qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<LireActionTacheDTO>> AfficherActionTacheAvecIdTacheAsync(int IdTache);

        /// <summary>
        /// Permet de créer un ActionTache dans la table ActionTache
        /// </summary>
        /// <param name="ActionTacheDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireActionTacheDTO> CreerActionTacheAsync(CreerActionTacheDTO ActionTacheDTO);

        /// <summary>
        /// Méthode pour supprimer un ActionTache de la base de donnée
        /// </summary>
        /// <param name="IdActionTache"> identifiant du ActionTache dans la tbale ActionTache</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireActionTacheDTO> SupprimerActionTacheAsync(int IdActionTache);

        /// <summary>
        /// Modifier les informations du ActionTache
        /// </summary>
        /// <param name="IdActionTache">Le ActionTache à modifier</param>
        /// <param name="ActionTacheDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireActionTacheDTO> ModifierActionTacheAsync(int IdActionTache, ModifierActionTacheDTO ActionTacheDTO);


    }
}
