using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Minekom.Infrastructure.Data.EntityFramework.Entities;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Minekom.Infrastructure.Data.EntityFramework;

public partial class MinekomContext : DbContext
{
    public MinekomContext()
    {
    }

    public MinekomContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<AbonnementFixe> AbonnementFixes { get; set; }

    public virtual DbSet<AbonnementFixeUtilisateur> AbonnementFixeUtilisateurs { get; set; }

    public virtual DbSet<AbonnementMobile> AbonnementMobiles { get; set; }

    public virtual DbSet<AbonnementMobileUtilisateur> AbonnementMobileUtilisateurs { get; set; }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<Antenne> Antennes { get; set; }

    public virtual DbSet<Frequence> Frequences { get; set; }

    public virtual DbSet<Statut> Statuts { get; set; }

    public virtual DbSet<Technologie> Technologies { get; set; }

    public virtual DbSet<TechnologieFrequence> TechnologieFrequences { get; set; }

    public virtual DbSet<Telephone> Telephones { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AbonnementFixe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("abonnement_fixe");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DebitDl)
                .HasColumnType("int(11)")
                .HasColumnName("debit_dl");
            entity.Property(e => e.DebitUp)
                .HasColumnType("int(11)")
                .HasColumnName("debit_up");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prix).HasColumnName("prix");
        });

        modelBuilder.Entity<AbonnementFixeUtilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("abonnement_fixe_utilisateur");

            entity.HasIndex(e => e.IdAbonnementFixe, "id_abonnement_fixe");

            entity.HasIndex(e => e.IdAdresse, "id_adresse");

            entity.HasIndex(e => e.IdUtilisateur, "id_utilisateur");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdAbonnementFixe)
                .HasColumnType("int(11)")
                .HasColumnName("id_abonnement_fixe");
            entity.Property(e => e.IdAdresse)
                .HasColumnType("int(11)")
                .HasColumnName("id_adresse");
            entity.Property(e => e.IdUtilisateur)
                .HasColumnType("int(11)")
                .HasColumnName("id_utilisateur");

            entity.HasOne(d => d.IdAbonnementFixeNavigation).WithMany(p => p.AbonnementFixeUtilisateurs)
                .HasForeignKey(d => d.IdAbonnementFixe)
                .HasConstraintName("abonnement_fixe_utilisateur_ibfk_1");

            entity.HasOne(d => d.IdAdresseNavigation).WithMany(p => p.AbonnementFixeUtilisateurs)
                .HasForeignKey(d => d.IdAdresse)
                .HasConstraintName("abonnement_fixe_utilisateur_ibfk_2");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.AbonnementFixeUtilisateurs)
                .HasForeignKey(d => d.IdUtilisateur)
                .HasConstraintName("abonnement_fixe_utilisateur_ibfk_3");
        });

        modelBuilder.Entity<AbonnementMobile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("abonnement_mobile");

            entity.HasIndex(e => e.TechnologieMax, "technologie_max");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DataMax)
                .HasColumnType("int(11)")
                .HasColumnName("data_max");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prix).HasColumnName("prix");
            entity.Property(e => e.TechnologieMax)
                .HasColumnType("int(11)")
                .HasColumnName("technologie_max");

            entity.HasOne(d => d.TechnologieMaxNavigation).WithMany(p => p.AbonnementMobiles)
                .HasForeignKey(d => d.TechnologieMax)
                .HasConstraintName("abonnement_mobile_ibfk_1");

            entity.HasMany(d => d.IdTechnologieFrequences).WithMany(p => p.IdAbonnementMobiles)
                .UsingEntity<Dictionary<string, object>>(
                    "AbonnementMobileTechnologieFrequence",
                    r => r.HasOne<TechnologieFrequence>().WithMany()
                        .HasForeignKey("IdTechnologieFrequence")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("abonnement_mobile_technologie_frequence_ibfk_2"),
                    l => l.HasOne<AbonnementMobile>().WithMany()
                        .HasForeignKey("IdAbonnementMobile")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("abonnement_mobile_technologie_frequence_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdAbonnementMobile", "IdTechnologieFrequence")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("abonnement_mobile_technologie_frequence");
                        j.HasIndex(new[] { "IdTechnologieFrequence" }, "id_technologie_frequence");
                        j.IndexerProperty<int>("IdAbonnementMobile")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_abonnement_mobile");
                        j.IndexerProperty<int>("IdTechnologieFrequence")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_technologie_frequence");
                    });
        });

        modelBuilder.Entity<AbonnementMobileUtilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("abonnement_mobile_utilisateur");

            entity.HasIndex(e => e.IdAbonnementMobile, "id_abonnement_mobile");

            entity.HasIndex(e => e.IdTelephone, "id_telephone");

            entity.HasIndex(e => e.IdUtilisateur, "id_utilisateur");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdAbonnementMobile)
                .HasColumnType("int(11)")
                .HasColumnName("id_abonnement_mobile");
            entity.Property(e => e.IdTelephone)
                .HasColumnType("int(11)")
                .HasColumnName("id_telephone");
            entity.Property(e => e.IdUtilisateur)
                .HasColumnType("int(11)")
                .HasColumnName("id_utilisateur");

            entity.HasOne(d => d.IdAbonnementMobileNavigation).WithMany(p => p.AbonnementMobileUtilisateurs)
                .HasForeignKey(d => d.IdAbonnementMobile)
                .HasConstraintName("abonnement_mobile_utilisateur_ibfk_1");

            entity.HasOne(d => d.IdTelephoneNavigation).WithMany(p => p.AbonnementMobileUtilisateurs)
                .HasForeignKey(d => d.IdTelephone)
                .HasConstraintName("abonnement_mobile_utilisateur_ibfk_3");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.AbonnementMobileUtilisateurs)
                .HasForeignKey(d => d.IdUtilisateur)
                .HasConstraintName("abonnement_mobile_utilisateur_ibfk_2");
        });

        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adresse");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CodePostal)
                .HasMaxLength(5)
                .HasColumnName("code_postal");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");
            entity.Property(e => e.Rue)
                .HasMaxLength(50)
                .HasColumnName("rue");
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .HasColumnName("ville");

            entity.HasMany(d => d.IdStatuts).WithMany(p => p.IdAdresses)
                .UsingEntity<Dictionary<string, object>>(
                    "Eligibilite",
                    r => r.HasOne<Statut>().WithMany()
                        .HasForeignKey("IdStatut")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("eligibilite_ibfk_2"),
                    l => l.HasOne<Adresse>().WithMany()
                        .HasForeignKey("IdAdresse")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("eligibilite_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdAdresse", "IdStatut")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("eligibilite");
                        j.HasIndex(new[] { "IdStatut" }, "id_statut");
                        j.IndexerProperty<int>("IdAdresse")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_adresse");
                        j.IndexerProperty<int>("IdStatut")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_statut");
                    });
        });

        modelBuilder.Entity<Antenne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("antenne");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.X)
                .HasColumnType("int(11)")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("int(11)")
                .HasColumnName("y");
            entity.Property(e => e.Z)
                .HasColumnType("int(11)")
                .HasColumnName("z");

            entity.HasMany(d => d.IdTechnologieAntennes).WithMany(p => p.IdAntennes)
                .UsingEntity<Dictionary<string, object>>(
                    "UtilisationAntenne",
                    r => r.HasOne<TechnologieFrequence>().WithMany()
                        .HasForeignKey("IdTechnologieAntenne")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("utilisation_antenne_ibfk_2"),
                    l => l.HasOne<Antenne>().WithMany()
                        .HasForeignKey("IdAntenne")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("utilisation_antenne_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdAntenne", "IdTechnologieAntenne")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("utilisation_antenne");
                        j.HasIndex(new[] { "IdTechnologieAntenne" }, "id_technologie_antenne");
                        j.IndexerProperty<int>("IdAntenne")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_antenne");
                        j.IndexerProperty<int>("IdTechnologieAntenne")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_technologie_antenne");
                    });
        });

        modelBuilder.Entity<Frequence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("frequence");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasColumnType("int(11)")
                .HasColumnName("label");
            entity.Property(e => e.Portee)
                .HasColumnType("int(11)")
                .HasColumnName("portee");
        });

        modelBuilder.Entity<Statut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statut");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Statut1)
                .HasMaxLength(50)
                .HasColumnName("statut");
        });

        modelBuilder.Entity<Technologie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("technologie");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Label)
                .HasMaxLength(10)
                .HasColumnName("label");
        });

        modelBuilder.Entity<TechnologieFrequence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("technologie_frequence");

            entity.HasIndex(e => e.IdFrequence, "id_frequence");

            entity.HasIndex(e => e.IdTechnologie, "id_technologie");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdFrequence)
                .HasColumnType("int(11)")
                .HasColumnName("id_frequence");
            entity.Property(e => e.IdTechnologie)
                .HasColumnType("int(11)")
                .HasColumnName("id_technologie");
            entity.Property(e => e.MaxDl)
                .HasColumnType("int(11)")
                .HasColumnName("max_DL");
            entity.Property(e => e.MaxUp)
                .HasColumnType("int(11)")
                .HasColumnName("max_UP");

            entity.HasOne(d => d.IdFrequenceNavigation).WithMany(p => p.TechnologieFrequences)
                .HasForeignKey(d => d.IdFrequence)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("technologie_frequence_ibfk_1");

            entity.HasOne(d => d.IdTechnologieNavigation).WithMany(p => p.TechnologieFrequences)
                .HasForeignKey(d => d.IdTechnologie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("technologie_frequence_ibfk_2");

            entity.HasMany(d => d.IdTelephones).WithMany(p => p.IdTechnologieFrequences)
                .UsingEntity<Dictionary<string, object>>(
                    "TelephoneTechnologieFrequence",
                    r => r.HasOne<Telephone>().WithMany()
                        .HasForeignKey("IdTelephone")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("telephone_technologie_frequence_ibfk_2"),
                    l => l.HasOne<TechnologieFrequence>().WithMany()
                        .HasForeignKey("IdTechnologieFrequence")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("telephone_technologie_frequence_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdTechnologieFrequence", "IdTelephone")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("telephone_technologie_frequence");
                        j.HasIndex(new[] { "IdTelephone" }, "id_telephone");
                        j.IndexerProperty<int>("IdTechnologieFrequence")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_technologie_frequence");
                        j.IndexerProperty<int>("IdTelephone")
                            .HasColumnType("int(11)")
                            .HasColumnName("id_telephone");
                    });
        });

        modelBuilder.Entity<Telephone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("telephone");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Marque)
                .HasMaxLength(50)
                .HasColumnName("marque");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prix).HasColumnName("prix");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("utilisateur");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateDeNaissance).HasColumnName("date_de_naissance");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("email");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(250)
                .HasColumnName("mot_de_passe");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .HasColumnName("telephone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
