using Kaban.Business.DTO.StatutDTO;
using Kaban.Business.Mapper.StatutMap;
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
    public class StatutService: IStatutService
    {
        private readonly IStatutRepository _StatutRepository;

        public StatutService(IStatutRepository StatutRepository)
        {
            _StatutRepository = StatutRepository;
        }

        /// <summary>
        /// Affiche le le Statut selon son indentifiant
        /// </summary>
        /// <param name="IdStatut">Identifiant du Statut qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireStatutDTO> AfficherStatutAvecIdStatutAsync(int IdStatut)
        {

            if (IdStatut == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var Statut = await _StatutRepository.SelecAvecIdStatut(IdStatut).ConfigureAwait(false);

            if (Statut == null)
            {
                throw new Exception($"Erreur: il n'a pas de Statut avec l'identifiant : {IdStatut}");

            }

            return StatutMapper.TransformEntityStatuttoLireStatutDTo(Statut);

        }


        /// <summary>
        /// Permet de créer un Statut dans la table Statut
        /// </summary>
        /// <param name="StatutDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireStatutDTO> CreerStatutAsync(CreerStatutDTO StatutDTO)
        {
            if (StatutDTO == null)
            {
                throw new ArgumentNullException(nameof(StatutDTO));
            }

            var StatutAjout = StatutMapper.TransformCreerStatutDTOtoEntity(StatutDTO);
            var nouveauStatut = await _StatutRepository.CreerStatut(StatutAjout);

            return StatutMapper.TransformEntityStatuttoLireStatutDTo(nouveauStatut);
        }

        /// <summary>
        /// Méthode pour supprimer un Statut de la base de donnée
        /// </summary>
        /// <param name="IdStatut"> identifiant du Statut dans la tbale Statut</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireStatutDTO> SupprimerStatutAsync(int IdStatut)
        {
            Statut Statut = await _StatutRepository.SelecAvecIdStatut(IdStatut).ConfigureAwait(false);

            if (Statut == null)
            {
                throw new Exception($"Erreur: il n'a pas de Statut avec l'identifiant : {IdStatut}");

            }

            //Mettre méthode pour vérifier que le Statut n'a pas d'avis ou des commandes à son nom

            Statut StatutSuppr = await _StatutRepository.SupprimerStatut(Statut).ConfigureAwait(false);

            return StatutMapper.TransformEntityStatuttoLireStatutDTo(StatutSuppr);
        }

        /// <summary>
        /// Modifier les informations du Statut
        /// </summary>
        /// <param name="IdStatut">Le Statut à modifier</param>
        /// <param name="StatutDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireStatutDTO> ModifierStatutAsync(int IdStatut, ModifierStatutDTO StatutDTO)
        {
            if (StatutDTO == null)
            {
                throw new ArgumentNullException(nameof(StatutDTO));
            }

            var StatutExist = await _StatutRepository.SelecAvecIdStatut(IdStatut).ConfigureAwait(false);

            if (StatutExist == null)
            {
                throw new Exception($"Il n'existe pas d'objectif Statut avec cet identifiant : {IdStatut}");
            }

            StatutExist.DescriptionStatus = StatutDTO.DescriptionStatus;

            //var StatutModifier = StatutMapper.TransformLireStatutDTOtoEntity(StatutExist);
            var modifStatut = await _StatutRepository.ModifierStatut(StatutExist).ConfigureAwait(false);

            return StatutMapper.TransformEntityStatuttoLireStatutDTo(modifStatut);
        }
    }
}
