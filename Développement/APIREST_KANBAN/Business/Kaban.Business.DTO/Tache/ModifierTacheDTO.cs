using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.TacheDTO
{
    public class ModifierTacheDTO
    {
        public int IdTache { get; set; }

        public string TitreTache { get; set; } = null!;

        public string? DescriptionTache { get; set; }

        public DateTime? DateCreation { get; set; }

        public DateTime? DateLimite { get; set; }

        public int IdUtilisateur { get; set; }

        public int IdStatut { get; set; }

        public int IdProjet { get; set; }
        public virtual ICollection<ActionTache> ActionTaches { get; set; } = new List<ActionTache>();

    }
}
