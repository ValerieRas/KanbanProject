using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Kaban.Data.Context.Contrat;
using Kaban.Data.Repository.Contrat;
using KANBAN.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Kaban.Data.Repository
{
    public class ActionTacheRepository : IActionTacheRepository
    {
        private readonly IKabanDBContext _DbContext;
        public ActionTacheRepository(IKabanDBContext Dbcontext)
        {
            _DbContext = Dbcontext;
        }

        /// <summary>
        /// Créer une action pour une tâche
        /// </summary>
        /// <param name="NewActiontache"></param>
        /// <returns></returns>
        public async Task<ActionTache> CreerActionTache(ActionTache NewActiontache)
        {

            var ActionTacheAjoute = await _DbContext.ActionTaches.AddAsync(NewActiontache).ConfigureAwait(false);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ActionTacheAjoute.Entity;
        }

        /// <summary>
        /// Supprime une action d'une tâche
        /// </summary>
        /// <param name="supprActionTache"></param>
        /// <returns></returns>
        public async Task<ActionTache> SupprimerActionTache(ActionTache supprActionTache)
        {

            var ActionTacheSupprime = _DbContext.ActionTaches.Remove(supprActionTache);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ActionTacheSupprime.Entity;
        }

        /// <summary>
        /// Modifier une action d'une tâche
        /// </summary>
        /// <param name="modifierActiontache"></param>
        /// <returns></returns>
        public async Task<ActionTache> ModifierActiontache(ActionTache modifierActiontache)
        {
            var ActionTacheModifier = _DbContext.ActionTaches.Update(modifierActiontache);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ActionTacheModifier.Entity;
        }



        /// <summary>
        /// Sélectionner une action d'une tache
        /// </summary>
        /// <param name="idActionTache"></param>
        /// <returns></returns>
        public async Task<ActionTache> SelecAvecIdActiontache(int idActionTache)
        {

            return await _DbContext.ActionTaches
                .Include(x => x.IdTacheNavigation)
                .FirstOrDefaultAsync(x => x.IdActionTache == idActionTache)
                .ConfigureAwait(false);

        }


        /// <summary>
        /// Liste toutes les actions d'une tâche spécifique
        /// </summary>
        /// <param name="idTache"></param>
        /// <returns></returns>
        public async Task<List<ActionTache>> SelecAvecIdtache(int idTache)
        {

            return await _DbContext.ActionTaches
                .Where(ActionTache => ActionTache.IdTache== idTache)
                .ToListAsync()
                .ConfigureAwait(false);

        }
    } 
}
