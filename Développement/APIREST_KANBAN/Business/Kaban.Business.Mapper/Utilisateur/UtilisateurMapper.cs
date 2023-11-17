using Kaban.Business.DTO.UtilisateurDTO;
using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.Mapper.UtilisateurMap
{
    public class UtilisateurMapper
    {

        /// <summary>
        /// Transforme le CreerUtilisateurDTo En entity
        /// </summary>
        /// <param name="creerUtilisateur">DTO avec les informations saisis par l'utilisatuer pour créer un nouveau Utilisateur</param>
        /// <returns></returns>
        public static Utilisateur TransformCreerUtilisateurDTOtoEntity(CreerUtilisateurDTO creerUtilisateur)
        {
            return new Utilisateur()
            {
                Nom = creerUtilisateur.Nom,
                Prenom= creerUtilisateur.Prenom,
                Email= creerUtilisateur.Email

            };

        }

        /// <summary>
        /// Transoforme 
        /// </summary>
        /// <param name="creerUtilisateur"></param>
        /// <returns></returns>
        public static LireUtilisateurDTO TransformEntityUtilisateurtoLireUtilisateurDTo(Utilisateur utilisateur)
        {
            return new LireUtilisateurDTO()
            {
                IdUtilisateur= utilisateur.IdUtilisateur,
                Nom = utilisateur.Nom,
                Prenom = utilisateur.Prenom,
                Email = utilisateur.Email

            };

        }



        /// <summary>
        /// Transforme le LireUtilisateurDTo En entity
        /// </summary>
        /// <param name="creerUtilisateur">DTO avec les informations saisis par l'utilisatue rpoiur créer un nouveau Utilisateur</param>
        /// <returns></returns>
        public static Utilisateur TransformLireUtilisateurDTOtoEntity(LireUtilisateurDTO modifUtilisateur)
        {
            return new Utilisateur()
            {
                IdUtilisateur = modifUtilisateur.IdUtilisateur,
                Nom = modifUtilisateur.Nom,
                Prenom = modifUtilisateur.Prenom,
                Email = modifUtilisateur.Email
            };

        }
    }
}
