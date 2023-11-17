using Kaban.Business.DTO.UtilisateurDTO;
using Kaban.Business.Mapper.UtilisateurMap;
using Kaban.Business.Service.Contrat;
using Kaban.Data.Repository.Contrat;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _UtilisateurRepository;

        public UtilisateurService(IUtilisateurRepository UtilisateurRepository)
        {
            _UtilisateurRepository = UtilisateurRepository;
        }

        /// <summary>
        /// Affiche le le Utilisateur selon son indentifiant
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant du Utilisateur qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireUtilisateurDTO>> AfficherUtilisateurAsync()
        {
            var utilisateurs = await _UtilisateurRepository.SelecUtilisateur().ConfigureAwait(false);
            List<LireUtilisateurDTO> les_lireClientDTo = new List<LireUtilisateurDTO>();

            foreach (Utilisateur utilisateur in utilisateurs)
            {
                les_lireClientDTo.Add(UtilisateurMapper.TransformEntityUtilisateurtoLireUtilisateurDTo(utilisateur));
            }

            return les_lireClientDTo;
        }

        /// <summary>
        /// Affiche les Utilisateur selon IdUtilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireUtilisateurDTO> AfficherUtilisateurAvecIdUtilisateurAsync(int IdUtilisateur)
        {

            if (IdUtilisateur == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var Utilisateur = await _UtilisateurRepository.SelecAvecIdUtilisateur(IdUtilisateur).ConfigureAwait(false);

            if (Utilisateur == null)
            {
                throw new Exception($"Erreur: il n'a pas de Utilisateur avec l'identifiant : {IdUtilisateur}");

            }

            return  UtilisateurMapper.TransformEntityUtilisateurtoLireUtilisateurDTo(Utilisateur);

        }

        /// <summary>
        /// Affiche les Utilisateur selon IdUtilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireUtilisateurDTO>> AfficherUtilisateurAvecIdProjetAsync(int IdProjet)
        {

            if (IdProjet == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var utilisateurs = await _UtilisateurRepository.SelecAvecIdProjetAsync(IdProjet).ConfigureAwait(false);

            if (utilisateurs == null)
            {
                throw new Exception($"Erreur: il n'a pas de projet avec l'identifiant : {IdProjet}");

            }

            List<LireUtilisateurDTO> les_lireClientDTo = new List<LireUtilisateurDTO>();

            foreach (Utilisateur utilisateur in utilisateurs)
            {
                les_lireClientDTo.Add(UtilisateurMapper.TransformEntityUtilisateurtoLireUtilisateurDTo(utilisateur));
            }

            return les_lireClientDTo;

        }

        /// <summary>
        /// Permet de créer un Utilisateur dans la table Utilisateur
        /// </summary>
        /// <param name="UtilisateurDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireUtilisateurDTO> CreerUtilisateurAsync(CreerUtilisateurDTO UtilisateurDTO)
        {
            if (UtilisateurDTO == null)
            {
                throw new ArgumentNullException(nameof(UtilisateurDTO));
            }

            var UtilisateurAjout = UtilisateurMapper.TransformCreerUtilisateurDTOtoEntity(UtilisateurDTO);
            var nouveauUtilisateur = await _UtilisateurRepository.CreerUtilisateur(UtilisateurAjout);

            return UtilisateurMapper.TransformEntityUtilisateurtoLireUtilisateurDTo(nouveauUtilisateur);
        }

        /// <summary>
        /// Méthode pour supprimer un Utilisateur de la base de donnée
        /// </summary>
        /// <param name="IdUtilisateur"> identifiant du Utilisateur dans la tbale Utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireUtilisateurDTO> SupprimerUtilisateurAsync(int IdUtilisateur)
        {
            Utilisateur Utilisateur = await _UtilisateurRepository.SelecAvecIdUtilisateur(IdUtilisateur).ConfigureAwait(false);

            if (Utilisateur == null)
            {
                throw new Exception($"Erreur: il n'a pas de Utilisateur avec l'identifiant : {IdUtilisateur}");

            }

            //Mettre méthode pour vérifier que le Utilisateur n'a pas d'avis ou des commandes à son nom

            Utilisateur UtilisateurSuppr = await _UtilisateurRepository.SupprimerUtilisateur(Utilisateur).ConfigureAwait(false);

            return UtilisateurMapper.TransformEntityUtilisateurtoLireUtilisateurDTo(UtilisateurSuppr);
        }

        /// <summary>
        /// Modifier les informations du Utilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Le Utilisateur à modifier</param>
        /// <param name="UtilisateurDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireUtilisateurDTO> ModifierUtilisateurAsync(int IdUtilisateur, ModifierUtilisateurDTO UtilisateurDTO)
        {
            if (UtilisateurDTO == null)
            {
                throw new ArgumentNullException(nameof(UtilisateurDTO));
            }

            var UtilisateurExist = await _UtilisateurRepository.SelecAvecIdUtilisateur(IdUtilisateur).ConfigureAwait(false);

            if (UtilisateurExist == null)
            {
                throw new Exception($"Il n'existe pas d'objectif Utilisateur avec cet identifiant : {IdUtilisateur}");
            }

            UtilisateurExist.Nom = UtilisateurDTO.Nom;
            UtilisateurExist.Prenom = UtilisateurDTO.Prenom;
            UtilisateurExist.Email = UtilisateurDTO.Email;

            //var UtilisateurModifier = UtilisateurMapper.TransformLireUtilisateurDTOtoEntity(UtilisateurExist);
            var modifUtilisateur = await _UtilisateurRepository.ModifierUtilisateur(UtilisateurExist).ConfigureAwait(false);

            return UtilisateurMapper.TransformEntityUtilisateurtoLireUtilisateurDTo(modifUtilisateur);
        }
    }
}
