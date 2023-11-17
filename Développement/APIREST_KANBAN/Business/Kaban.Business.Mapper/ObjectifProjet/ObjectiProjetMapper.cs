using Kaban.Business.DTO.ObjectifProjetDTO;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Mapper.ObjectifProjetMap
{
    public class ObjectiProjetMapper
    {
        /// <summary>
        /// Transforme le CreerObjectifProjetDTo En entity
        /// </summary>
        /// <param name="creerObjectifProjet">DTO avec les informations saisis par l'utilisatuer pour créer un nouveau ObjectifProjet</param>
        /// <returns></returns>
        public static ObjectifProjet TransformCreerObjectifProjetDTOtoEntity(CreerObjectifProjetDTO creerObjectifProjet)
        {
            return new ObjectifProjet()
            {
                DescriptionObjectif = creerObjectifProjet.DescriptionObjectif,
                Complete = creerObjectifProjet.Complete,
                IdProjet = creerObjectifProjet.IdProjet,


            };

        }

        /// <summary>
        /// Transoforme 
        /// </summary>
        /// <param name="creerObjectifProjet"></param>
        /// <returns></returns>
        public static LireObjectifProjetDTO TransformEntityObjectifProjettoLireObjectifProjetDTo(ObjectifProjet ObjectifProjet)
        {
            return new LireObjectifProjetDTO()
            {
                IdObjectifProjet = ObjectifProjet.IdObjectifProjet,
                DescriptionObjectif = ObjectifProjet.DescriptionObjectif,
                Complete = ObjectifProjet.Complete,
                IdProjet = ObjectifProjet.IdProjet,

            };



        }



        /// <summary>
        /// Transforme le LireObjectifProjetDTo En entity
        /// </summary>
        /// <param name="creerObjectifProjet">DTO avec les informations saisis par l'utilisatue rpoiur créer un nouveau ObjectifProjet</param>
        /// <returns></returns>
        public static ObjectifProjet TransformLireObjectifProjetDTOtoEntity(LireObjectifProjetDTO modifObjectifProjet)
        {
            return new ObjectifProjet()
            {
                IdObjectifProjet = modifObjectifProjet.IdObjectifProjet,
                DescriptionObjectif = modifObjectifProjet.DescriptionObjectif,
                Complete = modifObjectifProjet.Complete,
                IdProjet = modifObjectifProjet.IdProjet,
            };

        }
    }
}
