using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KANBAN.Data.Entity.Model;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string? Email { get; set; }
    [JsonIgnore]
    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
    [JsonIgnore]
    public virtual ICollection<Projet> IdProjets { get; set; } = new List<Projet>();
}
