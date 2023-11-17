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
    public class TacheRepository : ITacheRepository
    {
        private readonly IKabanDBContext _DbContext;
        public TacheRepository(IKabanDBContext Dbcontext)
        {
            _DbContext = Dbcontext;
        }

        /// <summary>
        /// Créer un tache dans un projet
        /// </summary>
        /// <param name="NewTache"></param>
        /// <returns></returns>
        public async Task<Tache> CreerTache(Tache NewTache)
        {

            var TacheAjoute = await _DbContext.Taches.AddAsync(NewTache).ConfigureAwait(false);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return TacheAjoute.Entity;
        }

        /// <summary>
        /// Supprimer une tache d'un projet
        /// </summary>
        /// <param name="supprTache"></param>
        /// <returns></returns>
        public async Task<Tache> SupprimerTache(Tache supprTache)
        {

            var TacheSupprime = _DbContext.Taches.Remove(supprTache);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return TacheSupprime.Entity;
        }


        /// <summary>
        /// Modifier une tache
        /// </summary>
        /// <param name="modifierTache"></param>
        /// <returns></returns>
        public async Task<Tache> ModifierTache(Tache modifierTache)
        {
            var TacheModifier = _DbContext.Taches.Update(modifierTache);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return TacheModifier.Entity;
        }

        /// <summary>
        /// Sélectionner une tâche avec son ID
        /// </summary>
        /// <param name="idTache"></param>
        /// <returns></returns>
        public async Task<Tache> SelecAvecIdTache(int idTache)
        {

            return await _DbContext.Taches
                .Include(x => x.ActionTaches)
                .Include(x => x.IdProjetNavigation)
                .Include(x => x.IdStatutNavigation)
                .Include(x => x.IdUtilisateurNavigation)
                .FirstOrDefaultAsync(x => x.IdTache == idTache)
                .ConfigureAwait(false);

        }

        /// <summary>
        /// Sélectionner toutes les tâches d'un projet
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        public async Task<List<Tache>> SelecAvecIdProjet(int idProjet)
        {

            return await _DbContext.Taches
                .Include(x => x.ActionTaches)
                .Include(x => x.IdProjetNavigation)
                .Include(x => x.IdStatutNavigation)
                .Include(x => x.IdUtilisateurNavigation)
                .Where(x => x.IdProjet == idProjet)
                .ToListAsync()
                .ConfigureAwait(false);

        }

        /// <summary>
        /// Sélectionner toutes les taches avec un statut spécifique
        /// </summary>
        /// <param name="idStatut"></param>
        /// <returns></returns>
        public async Task<List<Tache>> SelecAvecIdStatut(int idStatut)
        {
            return await _DbContext.Taches
                .Include(x => x.ActionTaches)
                .Include(x => x.IdProjetNavigation)
                .Include(x => x.IdStatutNavigation)
                .Include(x => x.IdUtilisateurNavigation)
                .Where(x => x.IdStatut == idStatut)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sélectionner toutes les taches d'un utilisateur
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <returns></returns>
        public async Task<List<Tache>> SelecAvecIdUtilisateur(int idUtilisateur)
        {

            return await _DbContext.Taches
                .Include(x => x.ActionTaches)
                .Include(x => x.IdProjetNavigation)
                .Include(x => x.IdStatutNavigation)
                .Include(x => x.IdUtilisateurNavigation)
                .Where(x => x.IdUtilisateur== idUtilisateur)
                .ToListAsync()
                .ConfigureAwait(false);

        }

    }
}
