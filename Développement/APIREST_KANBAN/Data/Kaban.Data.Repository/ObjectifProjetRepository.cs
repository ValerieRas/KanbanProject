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
    public class ObjectifProjetRepository: IObjectifProjetRepository
    {
        private readonly IKabanDBContext _DbContext;
        public ObjectifProjetRepository(IKabanDBContext Dbcontext)
        {
            _DbContext = Dbcontext;
        }

        /// <summary>
        ///  Créer un objectif pour un projet
        /// </summary>
        /// <param name="NewObjectifProjet"></param>
        /// <returns></returns>
        public async Task<ObjectifProjet> CreerObjectifProjet(ObjectifProjet NewObjectifProjet)
        {

            var ObjectifProjetAjoute = await _DbContext.ObjectifProjets.AddAsync(NewObjectifProjet).ConfigureAwait(false);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ObjectifProjetAjoute.Entity;
        }

        /// <summary>
        /// Supprimer un objectif d'un projet
        /// </summary>
        /// <param name="supprObjectifProjet"></param>
        /// <returns></returns>
        public async Task<ObjectifProjet> SupprimerObjectifProjet(ObjectifProjet supprObjectifProjet)
        {

            var ObjectifProjetSupprime = _DbContext.ObjectifProjets.Remove(supprObjectifProjet);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ObjectifProjetSupprime.Entity;
        }


        /// <summary>
        /// Modifier une un objectif d'un projet
        /// </summary>
        /// <param name="modifierObjectifProjet"></param>
        /// <returns></returns>
        public async Task<ObjectifProjet> ModifierObjectifProjet(ObjectifProjet modifierObjectifProjet)
        {
            var ObjectifProjetModifier = _DbContext.ObjectifProjets.Update(modifierObjectifProjet);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ObjectifProjetModifier.Entity;
        }

        /// <summary>
        /// Liste tous les objectifs d'un projet
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        public async Task<List<ObjectifProjet>> SelecAvecIdProjet(int idProjet)
        {


            return await _DbContext.ObjectifProjets
                .Where(ObjectifProjet => ObjectifProjet.IdProjet == idProjet)
                .ToListAsync()
                .ConfigureAwait(false);

        }

        /// <summary>
        /// Liste un objectif projet avec son id
        /// </summary>
        /// <param name="idObjectifProjet"></param>
        /// <returns></returns>
        public async Task<ObjectifProjet> SelecAvecIdObjectifProjet(int idObjectifProjet)
        {

            return await _DbContext.ObjectifProjets
                .Include(x => x.IdProjetNavigation)
                .FirstOrDefaultAsync(x => x.IdObjectifProjet == idObjectifProjet)
                .ConfigureAwait(false);

        }
    }
}
