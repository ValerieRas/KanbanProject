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
    public class StatutRepository : IStatutRepository
    {
        private readonly IKabanDBContext _DbContext;
        public StatutRepository(IKabanDBContext Dbcontext)
        {
            _DbContext = Dbcontext;
        }

        /// <summary>
        /// Créer un statut
        /// </summary>
        /// <param name="NewStatut"></param>
        /// <returns></returns>
        public async Task<Statut> CreerStatut(Statut NewStatut)
        {

            var StatutAjoute = await _DbContext.Statuts.AddAsync(NewStatut).ConfigureAwait(false);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return StatutAjoute.Entity;
        }

        /// <summary>
        /// Supprimer un statut
        /// </summary>
        /// <param name="supprStatut"></param>
        /// <returns></returns>
        public async Task<Statut> SupprimerStatut(Statut supprStatut)
        {

            var StatutSupprime = _DbContext.Statuts.Remove(supprStatut);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return StatutSupprime.Entity;
        }

        /// <summary>
        /// Lister tous les statuts
        /// </summary>
        /// <returns></returns>
        public async Task<List<Statut>> SelecStatut()
        {

            return await _DbContext.Statuts
                .Include(x => x.Taches)
                .Include(x => x.IdProjets)
                .ToListAsync()
                .ConfigureAwait(false);

        }

        /// <summary>
        /// Modifier un statut
        /// </summary>
        /// <param name="modifierStatut"></param>
        /// <returns></returns>
        public async Task<Statut> ModifierStatut(Statut modifierStatut)
        {
            var StatutModifier = _DbContext.Statuts.Update(modifierStatut);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return StatutModifier.Entity;
        }


        /// <summary>
        /// Sélectionner un statut avec ID
        /// </summary>
        /// <param name="idStatut"></param>
        /// <returns></returns>
        public async Task<Statut> SelecAvecIdStatut(int idStatut)
        {

            return await _DbContext.Statuts
                .Include(x => x.Taches)
                .Include(x => x.IdProjets)
                .FirstOrDefaultAsync(x => x.IdStatut == idStatut)
                .ConfigureAwait(false);

        }
    }
}
