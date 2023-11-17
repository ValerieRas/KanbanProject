using Kaban.Business.DTO.TacheDTO;
using Kaban.Business.Mapper.TacheMap;
using Kaban.Business.Service.Contrat;
using Kaban.Data.Repository.Contrat;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Service
{
    public class TacheService : ITacheService
    {
        private readonly ITacheRepository _TacheRepository;

        public TacheService(ITacheRepository TacheRepository)
        {
            _TacheRepository = TacheRepository;
        }

        /// <summary>
        /// Affiche le le Tache selon son indentifiant
        /// </summary>
        /// <param name="IdTache">Identifiant du Tache qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireTacheDTO> AfficherTacheAvecIdTacheAsync(int IdTache)
        {

            if (IdTache == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var Tache = await _TacheRepository.SelecAvecIdTache(IdTache).ConfigureAwait(false);

            if (Tache == null)
            {
                throw new Exception($"Erreur: il n'a pas de Tache avec l'identifiant : {IdTache}");

            }

            return TacheMapper.TransformEntityTachetoLireTacheDTo(Tache);

        }

        /// <summary>
        /// Affiche les Tache selon IdUtilisateur
        /// </summary>
        /// <param name="IdUtilisateur">Identifiant de l'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireTacheDTO>> AfficherTacheAvecIdUtilisateur(int IdUtilisateur)
        {

            if (IdUtilisateur == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

           var Taches = await _TacheRepository.SelecAvecIdUtilisateur(IdUtilisateur).ConfigureAwait(false);

            if (Taches == null)
            {
                throw new Exception($"Erreur: il n'a pas de Tache avec l'identifiant : {IdUtilisateur}");
            }

            List<LireTacheDTO> les_lireTacheDTo = new List<LireTacheDTO>();

            foreach (Tache tache in Taches)
            {
                les_lireTacheDTo.Add(TacheMapper.TransformEntityTachetoLireTacheDTo(tache));
            }

            return les_lireTacheDTo;

        }

        /// <summary>
        /// Affiche les Tache selon IdTache
        /// </summary>
        /// <param name="IdProjet">Identifiant du Tache param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireTacheDTO>> AfficherTacheAvecIdProjet(int IdProjet)
        {

            if (IdProjet == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var Taches = await _TacheRepository.SelecAvecIdProjet(IdProjet).ConfigureAwait(false);

            if (Taches == null)
            {
                throw new Exception($"Erreur: il n'a pas de Tache avec l'identifiant : {IdProjet}");

            }

            List<LireTacheDTO> les_lireTacheDTo = new List<LireTacheDTO>();

            foreach (Tache Tache in Taches)
            {
                les_lireTacheDTo.Add(TacheMapper.TransformEntityTachetoLireTacheDTo(Tache));
            }

            return les_lireTacheDTo;

        }

        /// <summary>
        /// Affiche les Tache selon IdStatut
        /// </summary>
        /// <param name="IdStatut">Identifiant du Statut</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireTacheDTO>> AfficherTacheAvecIdStatut(int IdStatut)
        {

            if (IdStatut == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var Taches = await _TacheRepository.SelecAvecIdStatut(IdStatut).ConfigureAwait(false);

            if (Taches == null)
            {
                throw new Exception($"Erreur: il n'a pas de Tache avec l'identifiant : {IdStatut}");

            }

            List<LireTacheDTO> les_lireTacheDTo = new List<LireTacheDTO>();

            foreach (Tache Tache in Taches)
            {
                les_lireTacheDTo.Add(TacheMapper.TransformEntityTachetoLireTacheDTo(Tache));
            }

            return les_lireTacheDTo;

        }


        /// <summary>
        /// Permet de créer un Tache dans la table Tache
        /// </summary>
        /// <param name="TacheDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireTacheDTO> CreerTacheAsync(CreerTacheDTO TacheDTO)
        {
            if (TacheDTO == null)
            {
                throw new ArgumentNullException(nameof(TacheDTO));
            }

            var TacheAjout = TacheMapper.TransformCreerTacheDTOtoEntity(TacheDTO);
            var nouveauTache = await _TacheRepository.CreerTache(TacheAjout);

            return TacheMapper.TransformEntityTachetoLireTacheDTo(nouveauTache);
        }

        /// <summary>
        /// Méthode pour supprimer un Tache de la base de donnée
        /// </summary>
        /// <param name="IdTache"> identifiant du Tache dans la tbale Tache</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireTacheDTO> SupprimerTacheAsync(int IdTache)
        {
            Tache Tache = await _TacheRepository.SelecAvecIdTache(IdTache).ConfigureAwait(false);

            if (Tache == null)
            {
                throw new Exception($"Erreur: il n'a pas de Tache avec l'identifiant : {IdTache}");

            }

            //Mettre méthode pour vérifier que le Tache n'a pas d'avis ou des commandes à son nom

            Tache TacheSuppr = await _TacheRepository.SupprimerTache(Tache).ConfigureAwait(false);

            return TacheMapper.TransformEntityTachetoLireTacheDTo(TacheSuppr);
        }

        /// <summary>
        /// Modifier les informations du Tache
        /// </summary>
        /// <param name="IdTache">Le Tache à modifier</param>
        /// <param name="TacheDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireTacheDTO> ModifierTacheAsync(int IdTache, ModifierTacheDTO TacheDTO)
        {
            if (TacheDTO == null)
            {
                throw new ArgumentNullException(nameof(TacheDTO));
            }

            var TacheExist = await _TacheRepository.SelecAvecIdTache(IdTache).ConfigureAwait(false);

            if (TacheExist == null)
            {
                throw new Exception($"Il n'existe pas d'objectif Tache avec cet identifiant : {IdTache}");
            }

            TacheExist.TitreTache = TacheDTO.TitreTache;
            TacheExist.DescriptionTache = TacheDTO.DescriptionTache;
            TacheExist.DateCreation = TacheDTO.DateCreation;
            TacheExist.DateLimite = TacheDTO.DateLimite;
            TacheExist.IdUtilisateur = TacheDTO.IdUtilisateur;
            TacheExist.IdStatut = TacheDTO.IdStatut;
            TacheExist.IdProjet = TacheDTO.IdProjet;
            TacheExist.ActionTaches = TacheDTO.ActionTaches;

            //var TacheModifier = TacheMapper.TransformLireTacheDTOtoEntity(TacheExist);
            var modifTache = await _TacheRepository.ModifierTache(TacheExist).ConfigureAwait(false);

            return TacheMapper.TransformEntityTachetoLireTacheDTo(modifTache);
        }
    }
}
