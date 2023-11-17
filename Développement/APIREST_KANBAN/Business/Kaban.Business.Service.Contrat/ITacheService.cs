using Kaban.Business.DTO.TacheDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service.Contrat
{
    public interface ITacheService
    {
        /// <summary>
        /// Affiche le le Tache selon son indentifiant
        /// </summary>
        /// <param name="IdTache">Identifiant du Tache qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireTacheDTO> AfficherTacheAvecIdTacheAsync(int IdTache);

        /// <summary>
        /// Affiche les Tache selon IdUtilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<LireTacheDTO>> AfficherTacheAvecIdUtilisateur(int IdUtilisateur);


        /// <summary>
        /// Affiche les Tache selon IdStatut
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant du Statut</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<LireTacheDTO>> AfficherTacheAvecIdStatut(int IdStatut);

        /// <summary>
        /// Affiche les Tache selon IdProjet
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant du projet param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<LireTacheDTO>> AfficherTacheAvecIdProjet(int IdProjet);


        /// <summary>
        /// Permet de créer un Tache dans la table Tache
        /// </summary>
        /// <param name="TacheDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireTacheDTO> CreerTacheAsync(CreerTacheDTO TacheDTO);


        /// <summary>
        /// Méthode pour supprimer un Tache de la base de donnée
        /// </summary>
        /// <param name="IdTache"> identifiant du Tache dans la tbale Tache</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<LireTacheDTO> SupprimerTacheAsync(int IdTache);



        /// <summary>
        /// Modifier les informations du Tache
        /// </summary>
        /// <param name="IdTache">Le Tache à modifier</param>
        /// <param name="TacheDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<LireTacheDTO> ModifierTacheAsync(int IdTache, ModifierTacheDTO TacheDTO);
    }
}
