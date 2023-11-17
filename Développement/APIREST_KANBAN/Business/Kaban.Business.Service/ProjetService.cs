using Kaban.Business.DTO.ObjectifProjetDTO;
using Kaban.Business.DTO.ProjetDTO;
using Kaban.Business.Mapper.ProjetMap;
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
    public class ProjetService : IProjetService
    {
        private readonly IProjetRepository _ProjetRepository;

        public ProjetService(IProjetRepository ProjetRepository)
        {
            _ProjetRepository = ProjetRepository;
        }

        /// <summary>
        /// Affiche le le projet selon son indentifiant
        /// </summary>
        /// <param name="IdProjet">Identifiant du Projet qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireProjetDTO> AfficherProjetAvecIdProjetAsync(int IdProjet)
        {

            if (IdProjet == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var Projet = await _ProjetRepository.SelecAvecIdProjet(IdProjet).ConfigureAwait(false);

            if (Projet == null)
            {
                throw new Exception($"Erreur: il n'a pas de Projet avec l'identifiant : {IdProjet}");

            }

            return ProjetMapper.TransformEntityProjettoLireProjetDTo(Projet);

        }

        /// <summary>
        /// Affiche les projet selon IdUtilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireProjetDTO>> AfficherProjetAvecIdUtilisateurAsync(int IdUtilisateur)
        {

            if (IdUtilisateur == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var projets = await _ProjetRepository.SelecAvecIdUtilisateur(IdUtilisateur).ConfigureAwait(false);

            if (projets == null)
            {
                throw new Exception($"Erreur: il n'a pas de Projet avec l'utilisateur : {IdUtilisateur}");

            }

            List<LireProjetDTO> les_lireProjetDTo = new List<LireProjetDTO>();

            foreach (Projet projet in projets)
            {
                les_lireProjetDTo.Add(ProjetMapper.TransformEntityProjettoLireProjetDTo(projet));
            }

            return les_lireProjetDTo;

        }


        /// <summary>
        /// Permet de créer un Projet dans la table Projet
        /// </summary>
        /// <param name="ProjetDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireProjetDTO> CreerProjetAsync(CreerProjetDTO ProjetDTO)
        {
            if (ProjetDTO == null)
            {
                throw new ArgumentNullException(nameof(ProjetDTO));
            }

            var ProjetAjout = ProjetMapper.TransformCreerProjetDTOtoEntity(ProjetDTO);
            var nouveauProjet = await _ProjetRepository.CreerProjet(ProjetAjout);

            return ProjetMapper.TransformEntityProjettoLireProjetDTo(nouveauProjet);
        }

        /// <summary>
        /// Méthode pour supprimer un Projet de la base de donnée
        /// </summary>
        /// <param name="IdProjet"> identifiant du Projet dans la tbale Projet</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireProjetDTO> SupprimerProjetAsync(int IdProjet)
        {
            Projet Projet = await _ProjetRepository.SelecAvecIdProjet(IdProjet).ConfigureAwait(false);

            if (Projet == null)
            {
                throw new Exception($"Erreur: il n'a pas de Projet avec l'identifiant : {IdProjet}");

            }

            //Mettre méthode pour vérifier que le Projet n'a pas d'avis ou des commandes à son nom

            Projet ProjetSuppr = await _ProjetRepository.SupprimerProjet(Projet).ConfigureAwait(false);

            return ProjetMapper.TransformEntityProjettoLireProjetDTo(ProjetSuppr);
        }

        /// <summary>
        /// Modifier les informations du Projet
        /// </summary>
        /// <param name="IdProjet">Le Projet à modifier</param>
        /// <param name="ProjetDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireProjetDTO> ModifierProjetAsync(int IdProjet, ModifierProjetDTO ProjetDTO)
        {
            if (ProjetDTO == null)
            {
                throw new ArgumentNullException(nameof(ProjetDTO));
            }

            var ProjetExist = await _ProjetRepository.SelecAvecIdProjet(IdProjet).ConfigureAwait(false);

            if (ProjetExist == null)
            {
                throw new Exception($"Il n'existe pas d'objectif projet avec cet identifiant : {IdProjet}");
            }

            ProjetExist.NomProjet = ProjetDTO.NomProjet;
            ProjetExist.DateDebut = ProjetDTO.DateDebut;
            ProjetExist.DateFin = ProjetDTO.DateFin;
            ProjetExist.ObjectifProjets = ProjetDTO.ObjectifProjets;
            ProjetExist.Taches = ProjetDTO.Taches;
            ProjetExist.IdUtilisateurs = ProjetDTO.IdUtilisateurs;
            ProjetExist.IdStatuts = ProjetDTO.IdStatuts;

            //var ProjetModifier = ProjetMapper.TransformLireProjetDTOtoEntity(ProjetExist);
            var modifProjet = await _ProjetRepository.ModifierProjet(ProjetExist).ConfigureAwait(false);

            return ProjetMapper.TransformEntityProjettoLireProjetDTo(modifProjet);
        }
    }
}
