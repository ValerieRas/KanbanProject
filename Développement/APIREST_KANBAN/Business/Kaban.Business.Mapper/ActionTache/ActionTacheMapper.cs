using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaban.Business.DTO.ActionTacheDTO;
using KANBAN.Data.Entity.Model;

namespace Kaban.Business.Mapper.ActionTacheMap
{
    public class ActionTacheMapper
    {

        /// <summary>
        /// Transforme le CreerActionTacheDTo En entity
        /// </summary>
        /// <param name="creerActionTache">DTO avec les informations saisis par l'utilisatuer pour créer un nouveau ActionTache</param>
        /// <returns></returns>
        public static ActionTache TransformCreerActionTacheDTOtoEntity(CreerActionTacheDTO creerActionTache)
        {
            return new ActionTache()
            {
                DescriptionAction = creerActionTache.DescriptionAction,
                Complete = creerActionTache.Complete,
                IdTache = creerActionTache.IdTache,


            };

        }

        /// <summary>
        /// Transoforme 
        /// </summary>
        /// <param name="creerActionTache"></param>
        /// <returns></returns>
        public static LireActionTacheDTO TransformEntityActionTachetoLireActionTacheDTo(ActionTache actionTache)
        {
            return new LireActionTacheDTO()
            {
                IdActionTache = actionTache.IdActionTache,
                DescriptionAction = actionTache.DescriptionAction,
                Complete = actionTache.Complete,
                IdTache = actionTache.IdTache,

            };



        }



        /// <summary>
        /// Transforme le LireActionTacheDTo En entity
        /// </summary>
        /// <param name="creerActionTache">DTO avec les informations saisis par l'utilisatue rpoiur créer un nouveau ActionTache</param>
        /// <returns></returns>
        public static ActionTache TransformLireActionTacheDTOtoEntity(LireActionTacheDTO modifActionTache)
        {
            return new ActionTache()
            {
                IdActionTache = modifActionTache.IdActionTache,
                DescriptionAction = modifActionTache.DescriptionAction,
                Complete = modifActionTache.Complete,
                IdTache = modifActionTache.IdTache,
            };

        }
    }
}
