using Kaban.Business.DTO.ProjetDTO;
using KANBAN.Data.Entity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Mapper.ProjetMap
{
    public class ProjetMapper
    {
        /// <summary>
        /// Transforme le CreerProjetDTo En entity
        /// </summary>
        /// <param name="creerProjet">DTO avec les informations saisis par l'utilisatuer pour créer un nouveau Projet</param>
        /// <returns></returns>
        public static Projet TransformCreerProjetDTOtoEntity(CreerProjetDTO creerProjet)
        {
            return new Projet()
            {
                NomProjet = creerProjet.nomProjet,
                ObjectifProjets= creerProjet.ObjectifProjets,
                DateDebut = creerProjet.dateDebut,
                DateFin = creerProjet.dateFin,
                IdUtilisateurs= creerProjet.IdUtilisateurs

            };

        }

        /// <summary>
        /// Transoforme 
        /// </summary>
        /// <param name="creerProjet"></param>
        /// <returns></returns>
        public static LireProjetDTO TransformEntityProjettoLireProjetDTo(Projet projet)
        {
            return new LireProjetDTO()
            {
                IdProjet = projet.IdProjet,
                NomProjet = projet.NomProjet,
                ObjectifProjets = projet.ObjectifProjets,
                DateDebut = projet.DateDebut,
                DateFin = projet.DateFin,
                IdUtilisateurs = projet.IdUtilisateurs,
               IdStatuts = projet.IdStatuts,
               Taches = projet.Taches
            };



        }



        /// <summary>
        /// Transforme le LireProjetDTo En entity
        /// </summary>
        /// <param name="creerProjet">DTO avec les informations saisis par l'utilisatue rpoiur créer un nouveau Projet</param>
        /// <returns></returns>
        public static Projet TransformLireProjetDTOtoEntity(LireProjetDTO modifProjet)
        {
            return new Projet()
            {
                IdProjet = modifProjet.IdProjet,
                NomProjet = modifProjet.NomProjet,
                ObjectifProjets = modifProjet.ObjectifProjets,
                DateDebut = modifProjet.DateDebut,
                DateFin = modifProjet.DateFin,
                Taches = modifProjet.Taches,
                IdUtilisateurs = modifProjet.IdUtilisateurs,
                IdStatuts = modifProjet.IdStatuts
        };

        }
    }
}
