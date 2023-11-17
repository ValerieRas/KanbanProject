using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.ProjetDTO
{
    public class CreerProjetDTO
    {

        public string nomProjet { get; set; } = null!;

        public DateTime dateDebut { get; set; }

        public DateTime? dateFin { get; set; }
        public virtual ICollection<ObjectifProjet> ObjectifProjets { get; set; } = new List<ObjectifProjet>();
        public virtual ICollection<Utilisateur> IdUtilisateurs { get; set; } = new List<Utilisateur>();
    }
}
