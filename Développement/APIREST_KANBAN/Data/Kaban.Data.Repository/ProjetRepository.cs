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
    public class ProjetRepository: IProjetRepository
    {

        private readonly IKabanDBContext _DbContext;
        public ProjetRepository(IKabanDBContext Dbcontext)
        {
            _DbContext = Dbcontext;
        }

        /// <summary>
        /// Créer un projet
        /// </summary>
        /// <param name="NewProjet"></param>
        /// <returns></returns>
        public async Task<Projet> CreerProjet(Projet NewProjet)
        {

            var ProjetAjoute = await _DbContext.Projets.AddAsync(NewProjet).ConfigureAwait(false);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ProjetAjoute.Entity;
        }

        /// <summary>
        /// Supprimer un projet
        /// </summary>
        /// <param name="supprProjet"></param>
        /// <returns></returns>
        public async Task<Projet> SupprimerProjet(Projet supprProjet)
        {

            var ProjetSupprime = _DbContext.Projets.Remove(supprProjet);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ProjetSupprime.Entity;
        }

        /// <summary>
        /// Modifier un projet
        /// </summary>
        /// <param name="modifierProjet"></param>
        /// <returns></returns>
        public async Task<Projet> ModifierProjet(Projet modifierProjet)
        {
            var ProjetModifier = _DbContext.Projets.Update(modifierProjet);
            await _DbContext.SaveChangeAsync().ConfigureAwait(false);

            return ProjetModifier.Entity;
        }


        /// <summary>
        /// Sélectionner un projet spécifique
        /// </summary>
        /// <param name="idProjet"></param>
        /// <returns></returns>
        public async Task<Projet> SelecAvecIdProjet(int idProjet)
        {

            return await _DbContext.Projets
                .Include(x => x.ObjectifProjets)
                .Include(x => x.Taches)
                .Include(x => x.IdStatuts)
                .Include(x => x.IdUtilisateurs)
                .FirstOrDefaultAsync(x => x.IdProjet == idProjet)
                .ConfigureAwait(false);

        }

        /// <summary>
        /// sélectionner une liste des projets d'un utilisateur
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <returns></returns>
        public async Task<List<Projet>> SelecAvecIdUtilisateur(int idUtilisateur)
        {

            return await _DbContext.Projets
           .Where(projet => projet.IdUtilisateurs.Any(User => User.IdUtilisateur == idUtilisateur))
           .ToListAsync()
           .ConfigureAwait(false);

        }



    }
}
