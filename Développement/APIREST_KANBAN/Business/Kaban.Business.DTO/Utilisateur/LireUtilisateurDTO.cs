using KANBAN.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaban.Business.DTO.UtilisateurDTO
{
    public class LireUtilisateurDTO
    {
        public int IdUtilisateur { get; set; }

        public string Nom { get; set; } = null!;

        public string Prenom { get; set; } = null!;

        public string? Email { get; set; }

        public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();

        public virtual ICollection<Projet> IdProjets { get; set; } = new List<Projet>();
    }
}
