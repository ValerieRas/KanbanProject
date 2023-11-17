using Kaban.Data.Context.Contrat;
using Kaban.Data.Repository.Contrat;
using KANBAN.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly IKabanDBContext _DbContext;
        public UtilisateurRepository(IKabanDBContext Dbcontext)
        {
            _DbContext = Dbcontext;
        }

        /// <summary>
        /// Créer un utilisateur
        /// </summary>
        /// <param name="NewUtilisateur"></param>
        /// <returns></returns>
        public async Task<Utilisateur> CreerUtilisateur(Utilisateur NewUtilisateur)
        {

            var UtilisateurAjoute = await _DbContext.Utilisateurs.AddAsync(NewUtilisateur).ConfigureAwait(false);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return UtilisateurAjoute.Entity;
        }

        /// <summary>
        /// Supprimer un utilisateur
        /// </summary>
        /// <param name="supprUtilisateur"></param>
        /// <returns></returns>
        public async Task<Utilisateur> SupprimerUtilisateur(Utilisateur supprUtilisateur)
        {

            var UtilisateurSupprime = _DbContext.Utilisateurs.Remove(supprUtilisateur);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return UtilisateurSupprime.Entity;
        }

        /// <summary>
        /// Lister tous les utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Utilisateur>> SelecUtilisateur()
        {

            return await _DbContext.Utilisateurs
                .Include(x => x.Taches)
                .Include(x => x.IdProjets)
                .ToListAsync()
                .ConfigureAwait(false);

        }


        /// <summary>
        /// Modifier un Utilisateur
        /// </summary>
        /// <param name="modifierUtilisateur"></param>
        /// <returns></returns>
        public async Task<Utilisateur> ModifierUtilisateur(Utilisateur modifierUtilisateur)
        {
            var UtilisateurModifier = _DbContext.Utilisateurs.Update(modifierUtilisateur);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return UtilisateurModifier.Entity;
        }


        /// <summary>
        /// sélectionner un utilisateur avec son ID 
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <returns></returns>
        public async Task<Utilisateur> SelecAvecIdUtilisateur(int idUtilisateur)
        {

            return await _DbContext.Utilisateurs
                .Include(x => x.Taches)
                .Include(x => x.IdProjets)
                .FirstOrDefaultAsync(x => x.IdUtilisateur == idUtilisateur)
                .ConfigureAwait(false);

        }

        /// <summary>
        /// sélectionner une liste d'utilisateur d'un projet
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        public async Task<List<Utilisateur>> SelecAvecIdProjetAsync(int idProjet)
        {
            return await _DbContext.Utilisateurs
                .Where(user => user.IdProjets.Any(projet=>projet.IdProjet==idProjet))
                .ToListAsync()
                .ConfigureAwait(false);
        }

    }
}
