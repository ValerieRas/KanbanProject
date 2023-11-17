using Kaban.Business.DTO.ProjetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service.Contrat
{
    public interface IProjetService
    {

        /// <summary>
        /// Affiche le le projet selon son indentifiant
        /// </summary>
        /// <param name="IdProjet">Identifiant du Projet qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireProjetDTO> AfficherProjetAvecIdProjetAsync(int IdProjet);

        /// <summary>
        /// Permet de créer un Projet dans la table Projet
        /// </summary>
        /// <param name="ProjetDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireProjetDTO> CreerProjetAsync(CreerProjetDTO ProjetDTO);


        /// <summary>
        /// Méthode pour supprimer un Projet de la base de donnée
        /// </summary>
        /// <param name="IdProjet"> identifiant du Projet dans la tbale Projet</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireProjetDTO> SupprimerProjetAsync(int IdProjet);

        /// <summary>
        /// Modifier les informations du Projet
        /// </summary>
        /// <param name="IdProjet">Le Projet à modifier</param>
        /// <param name="ProjetDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireProjetDTO> ModifierProjetAsync(int IdProjet, ModifierProjetDTO ProjetDTO);


        /// <summary>
        /// Affiche les projet selon IdUtilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<LireProjetDTO>> AfficherProjetAvecIdUtilisateurAsync(int IdUtilisateur);





        }
}
