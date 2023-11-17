using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KANBAN.Data.Entity.Model;

public partial class Statut
{
    public int IdStatut { get; set; }

    public string DescriptionStatus { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
    [JsonIgnore]
    public virtual ICollection<Projet> IdProjets { get; set; } = new List<Projet>();
}
