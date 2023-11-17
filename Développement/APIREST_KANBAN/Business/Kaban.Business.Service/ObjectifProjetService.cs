using Kaban.Business.DTO.ObjectifProjetDTO;
using Kaban.Business.Mapper.ObjectifProjetMap;
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
    public class ObjectifProjetService: IObjectifProjetService
    {

        private readonly IObjectifProjetRepository _ObjectifProjetRepository;

        public ObjectifProjetService(IObjectifProjetRepository ObjectifProjetRepository)
        {
            _ObjectifProjetRepository = ObjectifProjetRepository;
        }

        /// <summary>
        /// Affiche le lcient selon son indentifiant
        /// </summary>
        /// <param name="IdObjectifProjet">Identifiant du ObjectifProjet qu'on veut afficher</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<LireObjectifProjetDTO>> AfficherObjectifProjetAvecIdProjetAsync(int IdProjet)
        {

            if (IdProjet == 0)
            {
                throw new Exception($"Veuillez entrer un identifiant valide!");
            }

            var objectifProjets = await _ObjectifProjetRepository.SelecAvecIdProjet(IdProjet).ConfigureAwait(false);

            if (objectifProjets == null)
            {
                throw new Exception($"Erreur: il n'a pas de ObjectifProjet avec l'identifiant : {IdProjet}");

            }

            List<LireObjectifProjetDTO> les_lireObjectifProjetDTo = new List<LireObjectifProjetDTO>();

            foreach (ObjectifProjet ObjectifProjet in objectifProjets)
            {
                les_lireObjectifProjetDTo.Add(ObjectiProjetMapper.TransformEntityObjectifProjettoLireObjectifProjetDTo(ObjectifProjet));
            }

            return les_lireObjectifProjetDTo;
        }


        /// <summary>
        /// Permet de créer un ObjectifProjet dans la table ObjectifProjet
        /// </summary>
        /// <param name="ObjectifProjetDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireObjectifProjetDTO> CreerObjectifProjetAsync(CreerObjectifProjetDTO ObjectifProjetDTO)
        {
            if (ObjectifProjetDTO == null)
            {
                throw new ArgumentNullException(nameof(ObjectifProjetDTO));
            }

            var ObjectifProjetAjout = ObjectiProjetMapper.TransformCreerObjectifProjetDTOtoEntity(ObjectifProjetDTO);
            var nouveauObjectifProjet = await _ObjectifProjetRepository.CreerObjectifProjet(ObjectifProjetAjout);

            return ObjectiProjetMapper.TransformEntityObjectifProjettoLireObjectifProjetDTo(nouveauObjectifProjet);
        }

        /// <summary>
        /// Méthode pour supprimer un ObjectifProjet de la base de donnée
        /// </summary>
        /// <param name="IdObjectifProjet"> identifiant du ObjectifProjet dans la tbale ObjectifProjet</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<LireObjectifProjetDTO> SupprimerObjectifProjetAsync(int IdObjectifProjet)
        {
            ObjectifProjet objectifProjet = await _ObjectifProjetRepository.SelecAvecIdObjectifProjet(IdObjectifProjet).ConfigureAwait(false);

            if (objectifProjet == null)
            {
                throw new Exception($"Erreur: il n'a pas de ObjectifProjet avec l'identifiant : {IdObjectifProjet}");

            }

            //Mettre méthode pour vérifier que le ObjectifProjet n'a pas d'avis ou des commandes à son nom

            ObjectifProjet ObjectifProjetSuppr = await _ObjectifProjetRepository.SupprimerObjectifProjet(objectifProjet).ConfigureAwait(false);

            return ObjectiProjetMapper.TransformEntityObjectifProjettoLireObjectifProjetDTo(ObjectifProjetSuppr);
        }

        /// <summary>
        /// Modifier les informations du ObjectifProjet
        /// </summary>
        /// <param name="IdObjectifProjet">Le ObjectifProjet à modifier</param>
        /// <param name="ObjectifProjetDTO">Les infos à modifier</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<LireObjectifProjetDTO> ModifierObjectifProjetAsync(int IdObjectifProjet, ModifierObjectifProjetDTO ObjectifProjetDTO)
        {
            if (ObjectifProjetDTO == null)
            {
                throw new ArgumentNullException(nameof(ObjectifProjetDTO));
            }

            var ObjectifProjetExist = await _ObjectifProjetRepository.SelecAvecIdObjectifProjet(IdObjectifProjet).ConfigureAwait(false);

            if (ObjectifProjetExist == null)
            {
                throw new Exception($"Il n'existe pas d'objectif projet avec cet identifiant : {IdObjectifProjet}");
            }

            ObjectifProjetExist.DescriptionObjectif = ObjectifProjetDTO.DescriptionObjectif;
            ObjectifProjetExist.IdObjectifProjet = ObjectifProjetDTO.IdObjectifProjet;
            ObjectifProjetExist.Complete = ObjectifProjetDTO.Complete;


            //var ObjectifProjetModifier = ObjectifProjetMapper.TransformLireObjectifProjetDTOtoEntity(ObjectifProjetExist);
            var modifObjectifProjet = await _ObjectifProjetRepository.ModifierObjectifProjet(ObjectifProjetExist).ConfigureAwait(false);

            return ObjectiProjetMapper.TransformEntityObjectifProjettoLireObjectifProjetDTo(modifObjectifProjet);
        }
    }
}
