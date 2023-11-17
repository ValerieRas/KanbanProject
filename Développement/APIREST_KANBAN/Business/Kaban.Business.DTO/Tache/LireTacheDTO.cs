using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.TacheDTO
{
    public class LireTacheDTO
    {
        public int IdTache { get; set; }

        public string TitreTache { get; set; } = null!;

        public string? DescriptionTache { get; set; }

        public DateTime? DateCreation { get; set; }

        public DateTime? DateLimite { get; set; }


        public virtual ICollection<ActionTache> ActionTaches { get; set; } = new List<ActionTache>();

        public virtual Projet IdProjetNavigation { get; set; } = null!;

        public virtual Statut IdStatutNavigation { get; set; } = null!;

        public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;
    }
}
