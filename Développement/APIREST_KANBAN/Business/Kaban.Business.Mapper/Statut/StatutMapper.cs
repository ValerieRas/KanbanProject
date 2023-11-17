using Kaban.Business.DTO.StatutDTO;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Mapper.StatutMap
{
    public class StatutMapper
    {
        /// <summary>
        /// Transforme le CreerStatutDTo En entity
        /// </summary>
        /// <param name="creerStatut">DTO avec les informations saisis par l'utilisatuer pour créer un nouveau Statut</param>
        /// <returns></returns>
        public static Statut TransformCreerStatutDTOtoEntity(CreerStatutDTO creerStatut)
        {
            return new Statut()
            {
                DescriptionStatus = creerStatut.DescriptionStatus,

            };

        }

        /// <summary>
        /// Transoforme 
        /// </summary>
        /// <param name="creerStatut"></param>
        /// <returns></returns>
        public static LireStatutDTO TransformEntityStatuttoLireStatutDTo(Statut statut)
        {
            return new LireStatutDTO()
            {
                IdStatut = statut.IdStatut,
                DescriptionStatus = statut.DescriptionStatus

            };

        }



        /// <summary>
        /// Transforme le LireStatutDTo En entity
        /// </summary>
        /// <param name="creerStatut">DTO avec les informations saisis par l'utilisatue rpoiur créer un nouveau Statut</param>
        /// <returns></returns>
        public static Statut TransformLireStatutDTOtoEntity(LireStatutDTO modifStatut)
        {
            return new Statut()
            {
                IdStatut = modifStatut.IdStatut,
                DescriptionStatus = modifStatut.DescriptionStatus
            };

        }
    }
}
