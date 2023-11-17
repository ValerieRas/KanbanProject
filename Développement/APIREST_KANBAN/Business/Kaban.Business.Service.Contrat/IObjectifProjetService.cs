using Kaban.Business.DTO.ObjectifProjetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service.Contrat
{
    public interface IObjectifProjetService
    {

        /// <summary>
        /// Affiche le lcient selon son indentifiant
        /// </summary>
        /// <param name="IdObjectifProjet">Identifiant du ObjectifProjet qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<LireObjectifProjetDTO>> AfficherObjectifProjetAvecIdProjetAsync(int IdProjet);


        /// <summary>
        /// Permet de créer un ObjectifProjet dans la table ObjectifProjet
        /// </summary>
        /// <param name="ObjectifProjetDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireObjectifProjetDTO> CreerObjectifProjetAsync(CreerObjectifProjetDTO ObjectifProjetDTO);

        /// <summary>
        /// Méthode pour supprimer un ObjectifProjet de la base de donnée
        /// </summary>
        /// <param name="IdObjectifProjet"> identifiant du ObjectifProjet dans la tbale ObjectifProjet</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireObjectifProjetDTO> SupprimerObjectifProjetAsync(int IdObjectifProjet);


        /// <summary>
        /// Modifier les informations du ObjectifProjet
        /// </summary>
        /// <param name="IdObjectifProjet">Le ObjectifProjet à modifier</param>
        /// <param name="ObjectifProjetDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireObjectifProjetDTO> ModifierObjectifProjetAsync(int IdObjectifProjet, ModifierObjectifProjetDTO ObjectifProjetDTO);




    }
}
