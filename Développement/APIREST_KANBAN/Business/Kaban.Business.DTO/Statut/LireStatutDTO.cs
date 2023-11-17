using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.StatutDTO
{
    public class LireStatutDTO
    {
        public int IdStatut { get; set; }

        public string DescriptionStatus { get; set; } = null!;

        public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();

        public virtual ICollection<Projet> IdProjets { get; set; } = new List<Projet>();
    }
}
