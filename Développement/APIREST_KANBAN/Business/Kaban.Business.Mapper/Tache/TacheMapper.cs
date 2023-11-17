using Kaban.Business.DTO.TacheDTO;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Mapper.TacheMap
{
    public class TacheMapper
    {
        /// <summary>
        /// Transforme le CreerTacheDTo En entity
        /// </summary>
        /// <param name="creerTache">DTO avec les informations saisis par l'utilisatuer pour créer un nouveau Tache</param>
        /// <returns></returns>
        public static Tache TransformCreerTacheDTOtoEntity(CreerTacheDTO creerTache)
        {
            return new Tache()
            {
                TitreTache=creerTache.TitreTache,

                DescriptionTache =creerTache.DescriptionTache,

                DateCreation =creerTache.DateCreation,

                DateLimite =creerTache.DateLimite,

                IdUtilisateur =creerTache.IdUtilisateur,

                IdStatut =creerTache.IdStatut,

                IdProjet =creerTache.IdProjet,
            };

        }

        /// <summary>
        /// Transoforme 
        /// </summary>
        /// <param name="creerTache"></param>
        /// <returns></returns>
        public static LireTacheDTO TransformEntityTachetoLireTacheDTo(Tache tache)
        {
            return new LireTacheDTO()
            {
                IdTache = tache.IdTache,

                TitreTache = tache.TitreTache,

                DescriptionTache = tache.DescriptionTache,

                DateCreation = tache.DateCreation,

                DateLimite = tache.DateLimite,

                ActionTaches=tache.ActionTaches,

                IdUtilisateurNavigation = tache.IdUtilisateurNavigation,

                IdStatutNavigation = tache.IdStatutNavigation,

                IdProjetNavigation = tache.IdProjetNavigation

            };

        }



        /// <summary>
        /// Transforme le LireTacheDTo En entity
        /// </summary>
        /// <param name="creerTache">DTO avec les informations saisis par l'utilisatue rpoiur créer un nouveau Tache</param>
        /// <returns></returns>
        public static Tache TransformLireTacheDTOtoEntity(LireTacheDTO modifTache)
        {
            return new Tache()
            {
                IdTache = modifTache.IdTache,

                TitreTache = modifTache.TitreTache,

                DescriptionTache = modifTache.DescriptionTache,

                DateCreation = modifTache.DateCreation,

                DateLimite = modifTache.DateLimite,

                ActionTaches = modifTache.ActionTaches,

                IdUtilisateurNavigation = modifTache.IdUtilisateurNavigation,

                IdStatutNavigation = modifTache.IdStatutNavigation,

                IdProjetNavigation = modifTache.IdProjetNavigation
            };

        }
    }
}
