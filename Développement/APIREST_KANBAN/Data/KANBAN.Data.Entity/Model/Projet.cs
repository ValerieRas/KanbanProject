using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KANBAN.Data.Entity.Model;

public partial class Projet
{
    public int IdProjet { get; set; }

    public string NomProjet { get; set; } = null!;

    public DateTime DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    [JsonIgnore]
    public virtual ICollection<ObjectifProjet> ObjectifProjets { get; set; } = new List<ObjectifProjet>();
    [JsonIgnore]
    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
    [JsonIgnore]
    public virtual ICollection<Statut> IdStatuts { get; set; } = new List<Statut>();
    [JsonIgnore]
    public virtual ICollection<Utilisateur> IdUtilisateurs { get; set; } = new List<Utilisateur>();
}
