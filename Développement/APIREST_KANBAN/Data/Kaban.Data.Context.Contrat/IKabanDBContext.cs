using KANBAN.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Data.Context.Contrat
{
    public interface IKabanDBContext:IDbContext
    {
        DbSet<ActionTache> ActionTaches { get; set; }

        DbSet<ObjectifProjet> ObjectifProjets { get; set; }

        DbSet<Projet> Projets { get; set; }

        DbSet<Statut> Statuts { get; set; }

        DbSet<Tache> Taches { get; set; }

        DbSet<Utilisateur> Utilisateurs { get; set; }
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangeAsync(bool AcceptAllChangesOnSucces, CancellationToken cancellationToken = default);
    }
}
