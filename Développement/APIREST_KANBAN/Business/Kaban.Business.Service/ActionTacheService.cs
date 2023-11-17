
using Kaban.Business.DTO.ActionTacheDTO;
using Kaban.Business.DTO.UtilisateurDTO;
using Kaban.Business.Mapper.ActionTacheMap;
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
    public class ActionTacheService : IActionTacheService
    {
        private readonly IActionTacheRepository _ActionTacheRepository;

        public ActionTacheService(IActionTacheRepository ActionTacheRepository)
        {
            _ActionTacheRepository = ActionTacheRepository;
        }

        /// <summary>
        /// Affiche le lcient selon son indentifiant
        /// </summary>
        /// <param name="IdActionTache">Identifiant du ActionTache qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireActionTacheDTO>> AfficherActionTacheAvecIdTacheAsync(int IdTache)
        {

            if (IdTache == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var ActionTaches = await _ActionTacheRepository.SelecAvecIdtache(IdTache).ConfigureAwait(false);

            if (ActionTaches == null)
            {
                throw new Exception($"Erreur: il n'a pas de ActionTache avec l'identifiant : {IdTache}");

            }

            List<LireActionTacheDTO> les_lireClientDTo = new List<LireActionTacheDTO>();

            foreach (ActionTache actionTache in ActionTaches)
            {
                les_lireClientDTo.Add(ActionTacheMapper.TransformEntityActionTachetoLireActionTacheDTo(actionTache));
            }

            return les_lireClientDTo;

        }


        /// <summary>
        /// Permet de créer un ActionTache dans la table ActionTache
        /// </summary>
        /// <param name="ActionTacheDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireActionTacheDTO> CreerActionTacheAsync(CreerActionTacheDTO ActionTacheDTO)
        {
            if (ActionTacheDTO == null)
            {
                throw new ArgumentNullException(nameof(ActionTacheDTO));
            }

            var ActionTacheAjout = ActionTacheMapper.TransformCreerActionTacheDTOtoEntity(ActionTacheDTO);
            var nouveauActionTache = await _ActionTacheRepository.CreerActionTache(ActionTacheAjout);

            return ActionTacheMapper.TransformEntityActionTachetoLireActionTacheDTo(nouveauActionTache);
        }

        /// <summary>
        /// Méthode pour supprimer un ActionTache de la base de donnée
        /// </summary>
        /// <param name="IdActionTache"> identifiant du ActionTache dans la tbale ActionTache</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireActionTacheDTO> SupprimerActionTacheAsync(int IdActionTache)
        {
            ActionTache ActionTache = await _ActionTacheRepository.SelecAvecIdActiontache(IdActionTache).ConfigureAwait(false);

            if (ActionTache == null)
            {
                throw new Exception($"Erreur: il n'a pas de ActionTache avec l'identifiant : {IdActionTache}");

            }

            //Mettre méthode pour vérifier que le ActionTache n'a pas d'avis ou des commandes à son nom

            ActionTache ActionTacheSuppr = await _ActionTacheRepository.SupprimerActionTache(ActionTache).ConfigureAwait(false);

            return ActionTacheMapper.TransformEntityActionTachetoLireActionTacheDTo(ActionTacheSuppr);
        }

        /// <summary>
        /// Modifier les informations du ActionTache
        /// </summary>
        /// <param name="IdActionTache">Le ActionTache à modifier</param>
        /// <param name="ActionTacheDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireActionTacheDTO> ModifierActionTacheAsync(int IdActionTache, ModifierActionTacheDTO ActionTacheDTO)
        {
            if (ActionTacheDTO == null)
            {
                throw new ArgumentNullException(nameof(ActionTacheDTO));
            }

            var ActionTacheExist = await _ActionTacheRepository.SelecAvecIdActiontache(IdActionTache).ConfigureAwait(false);

            if (ActionTacheExist == null)
            {
                throw new Exception($"Il n'existe aucune unité de mesure avec cet identifiant : {IdActionTache}");
            }

            ActionTacheExist.DescriptionAction = ActionTacheDTO.DescriptionAction;
            ActionTacheExist.IdTache = ActionTacheDTO.IdTache;
            ActionTacheExist.Complete = ActionTacheDTO.Complete;
   

            //var ActionTacheModifier = ActionTacheMapper.TransformLireActionTacheDTOtoEntity(ActionTacheExist);
            var modifActionTache = await _ActionTacheRepository.ModifierActiontache(ActionTacheExist).ConfigureAwait(false);

            return ActionTacheMapper.TransformEntityActionTachetoLireActionTacheDTo(modifActionTache);
        }
    }
}
