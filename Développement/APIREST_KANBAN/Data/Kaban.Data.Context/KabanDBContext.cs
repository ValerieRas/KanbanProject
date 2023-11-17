using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using KANBAN.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Kaban.Data.Context.Contrat;

namespace KANBAN.Data.Entity;

public partial class KanbanDBContext : DbContext, IKabanDBContext
{
    public KanbanDBContext()
    {
    }

    public KanbanDBContext(DbContextOptions<KanbanDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionTache> ActionTaches { get; set; }

    public virtual DbSet<ObjectifProjet> ObjectifProjets { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<Statut> Statuts { get; set; }

    public virtual DbSet<Tache> Taches { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }


    public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SaveChangeAsync(bool AcceptAllChangesOnSucces, CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionTache>(entity =>
        {
            entity.HasKey(e => e.IdActionTache).HasName("PK__Action_t__DC86BB5E16876A4A");

            entity.ToTable("Action_tache");

            entity.Property(e => e.IdActionTache).HasColumnName("ID_action_tache");
            entity.Property(e => e.DescriptionAction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdTache).HasColumnName("ID_tache");

            entity.HasOne(d => d.IdTacheNavigation).WithMany(p => p.ActionTaches)
                .HasForeignKey(d => d.IdTache)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Action_ta__ID_ta__44FF419A");
        });

        modelBuilder.Entity<ObjectifProjet>(entity =>
        {
            entity.HasKey(e => e.IdObjectifProjet).HasName("PK__Objectif__22113FCAB17E30AF");

            entity.ToTable("Objectif_projet");

            entity.Property(e => e.IdObjectifProjet).HasColumnName("ID_objectif_projet");
            entity.Property(e => e.DescriptionObjectif)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdProjet).HasColumnName("ID_projet");

            entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.ObjectifProjets)
                .HasForeignKey(d => d.IdProjet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Objectif___ID_pr__3B75D760");
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasKey(e => e.IdProjet).HasName("PK__Projet__2396BD54A70705FC");

            entity.ToTable("Projet");

            entity.Property(e => e.IdProjet).HasColumnName("ID_projet");
            entity.Property(e => e.DateDebut).HasColumnType("date");
            entity.Property(e => e.DateFin).HasColumnType("date");
            entity.Property(e => e.NomProjet)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdStatuts).WithMany(p => p.IdProjets)
                .UsingEntity<Dictionary<string, object>>(
                    "StatutProjet",
                    r => r.HasOne<Statut>().WithMany()
                        .HasForeignKey("IdStatut")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Statut_pr__ID_st__4CA06362"),
                    l => l.HasOne<Projet>().WithMany()
                        .HasForeignKey("IdProjet")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Statut_pr__ID_pr__4BAC3F29"),
                    j =>
                    {
                        j.HasKey("IdProjet", "IdStatut").HasName("PK__Statut_p__47DF002A2883FDDB");
                        j.ToTable("Statut_projet");
                        j.IndexerProperty<int>("IdProjet").HasColumnName("ID_projet");
                        j.IndexerProperty<int>("IdStatut").HasColumnName("ID_statut");
                    });
        });

        modelBuilder.Entity<Statut>(entity =>
        {
            entity.HasKey(e => e.IdStatut).HasName("PK__Statut__449BD7E7214283DB");

            entity.ToTable("Statut");

            entity.Property(e => e.IdStatut).HasColumnName("ID_statut");
            entity.Property(e => e.DescriptionStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.HasKey(e => e.IdTache).HasName("PK__Tache__55401D454D22EEF8");

            entity.ToTable("Tache");

            entity.Property(e => e.IdTache).HasColumnName("ID_tache");
            entity.Property(e => e.DateCreation).HasColumnType("date");
            entity.Property(e => e.DateLimite).HasColumnType("date");
            entity.Property(e => e.DescriptionTache)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdProjet).HasColumnName("ID_projet");
            entity.Property(e => e.IdStatut).HasColumnName("ID_statut");
            entity.Property(e => e.IdUtilisateur).HasColumnName("ID_utilisateur");
            entity.Property(e => e.TitreTache)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.IdProjet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tache__ID_projet__4222D4EF");

            entity.HasOne(d => d.IdStatutNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.IdStatut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tache__ID_statut__412EB0B6");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.IdUtilisateur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tache__ID_utilis__403A8C7D");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur).HasName("PK__Utilisat__DBEF746A7CA96390");

            entity.ToTable("Utilisateur");

            entity.Property(e => e.IdUtilisateur).HasColumnName("ID_utilisateur");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdProjets).WithMany(p => p.IdUtilisateurs)
                .UsingEntity<Dictionary<string, object>>(
                    "MembreProjet",
                    r => r.HasOne<Projet>().WithMany()
                        .HasForeignKey("IdProjet")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Membre_pr__ID_pr__48CFD27E"),
                    l => l.HasOne<Utilisateur>().WithMany()
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Membre_pr__ID_ut__47DBAE45"),
                    j =>
                    {
                        j.HasKey("IdUtilisateur", "IdProjet").HasName("PK__Membre_p__89D61FBF582A8A2E");
                        j.ToTable("Membre_projet");
                        j.IndexerProperty<int>("IdUtilisateur").HasColumnName("ID_utilisateur");
                        j.IndexerProperty<int>("IdProjet").HasColumnName("ID_projet");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
