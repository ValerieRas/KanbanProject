using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.ProjetDTO
{
    public class LireProjetDTO
    {
        public int IdProjet { get; set; }

        public string NomProjet { get; set; } = null!;

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

   
        public virtual ICollection<ObjectifProjet> ObjectifProjets { get; set; } = new List<ObjectifProjet>();

        public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();

        public virtual ICollection<Statut> IdStatuts { get; set; } = new List<Statut>();

        public virtual ICollection<Utilisateur> IdUtilisateurs { get; set; } = new List<Utilisateur>();
    }
}
