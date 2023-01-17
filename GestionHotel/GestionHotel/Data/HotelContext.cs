using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GestionHotel.Data.Models;

#nullable disable

namespace GestionHotel.Data
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chambre> Chambres { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Entreprise> Entreprises { get; set; }
        public virtual DbSet<EquipementsChambre> Equipementschambres { get; set; }
        public virtual DbSet<Etage> Etages { get; set; }
        public virtual DbSet<Facturation> Facturations { get; set; }
        public virtual DbSet<Fidelite> Fidelites { get; set; }
        public virtual DbSet<HistoriqueActionsReservation> Historiqueactionsreservations { get; set; }
        public virtual DbSet<HistoriqueChambre> Historiquechambres { get; set; }
        public virtual DbSet<HistoriquesNettoyage> Historiquesnettoyages { get; set; }
        public virtual DbSet<Particulier> Particuliers { get; set; }
        public virtual DbSet<PossessionsEquipement> Possessionsequipements { get; set; }
        public virtual DbSet<Prestation> Prestations { get; set; }
        public virtual DbSet<ReservationsSejour> Reservationssejours { get; set; }
        public virtual DbSet<StatutsChambre> Statutschambres { get; set; }
        public virtual DbSet<TypesChambre> Typeschambres { get; set; }
        public virtual DbSet<TypesEmploye> Typesemployes { get; set; }
        public virtual DbSet<TypesPaiement> Typespaiements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;database=projethotel;port=3306;ssl mode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chambre>(entity =>
            {
                entity.HasKey(e => e.IdChambre)
                    .HasName("PRIMARY");

                entity.ToTable("chambres");

                entity.HasIndex(e => e.IdEtage, "FK_Chambres_Etages");

                entity.HasIndex(e => e.IdStatutChambre, "FK_Chambres_StatutsChambres");

                entity.HasIndex(e => e.IdTypeChambre, "FK_Chambres_TypesChambres");

                entity.HasIndex(e => e.NumChambre, "NumChambre")
                    .IsUnique();

                entity.Property(e => e.IdChambre).HasColumnType("int(11)");

                entity.Property(e => e.IdEtage).HasColumnType("int(11)");

                entity.Property(e => e.IdStatutChambre).HasColumnType("int(11)");

                entity.Property(e => e.IdTypeChambre).HasColumnType("int(11)");

                entity.Property(e => e.NumChambre).HasColumnType("int(11)");

                entity.HasOne(d => d.EtageObj)
                    .WithMany(p => p.Chambres)
                    .HasForeignKey(d => d.IdEtage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chambres_Etages");

                entity.HasOne(d => d.StatutChambreObj)
                    .WithMany(p => p.Chambres)
                    .HasForeignKey(d => d.IdStatutChambre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chambres_StatutsChambres");

                entity.HasOne(d => d.TypeChambreObj)
                    .WithMany(p => p.Chambres)
                    .HasForeignKey(d => d.IdTypeChambre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chambres_TypesChambres");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("clients");

                entity.Property(e => e.IdClient).HasColumnType("int(11)");

                entity.Property(e => e.MailClient).HasMaxLength(100);

                entity.Property(e => e.NomClient).HasMaxLength(50);

                entity.Property(e => e.PrenomClient).HasMaxLength(50);

                entity.Property(e => e.TelClient).HasMaxLength(20);
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.HasKey(e => e.IdEmploye)
                    .HasName("PRIMARY");

                entity.ToTable("employes");

                entity.HasIndex(e => e.IdTypeEmploye, "FK_Employes_TypeEmployes");

                entity.HasIndex(e => e.Identifiant, "Identifiant")
                    .IsUnique();

                entity.Property(e => e.IdEmploye).HasColumnType("int(11)");

                entity.Property(e => e.IdTypeEmploye).HasColumnType("int(11)");

                entity.Property(e => e.Identifiant)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mdp)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NomEmploye).HasMaxLength(50);

                entity.Property(e => e.PrenomEmploye).HasMaxLength(50);

                entity.HasOne(d => d.TypeEmploye)
                    .WithMany(p => p.Employes)
                    .HasForeignKey(d => d.IdTypeEmploye)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employes_TypeEmployes");
            });

            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("entreprises");

                entity.HasIndex(e => e.NumEntreprise, "NumEntreprise")
                    .IsUnique();

                entity.HasIndex(e => e.Siret, "Siret")
                    .IsUnique();

                entity.Property(e => e.IdClient).HasColumnType("int(11)");

                entity.Property(e => e.NomEntreprise).HasMaxLength(100);

                entity.Property(e => e.NumEntreprise).HasColumnType("int(11)");

                entity.Property(e => e.PourcentageReduction).HasColumnType("decimal(15,2)");

                entity.Property(e => e.Siret).HasMaxLength(50);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithOne(p => p.Entreprise)
                    .HasForeignKey<Entreprise>(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entreprises_Clients");
            });

            modelBuilder.Entity<EquipementsChambre>(entity =>
            {
                entity.HasKey(e => e.IdEquipementChambre)
                    .HasName("PRIMARY");

                entity.ToTable("equipementschambres");

                entity.Property(e => e.IdEquipementChambre).HasColumnType("int(11)");

                entity.Property(e => e.LibelleEquipementChambre).HasMaxLength(50);
            });

            modelBuilder.Entity<Etage>(entity =>
            {
                entity.HasKey(e => e.IdEtage)
                    .HasName("PRIMARY");

                entity.ToTable("etages");

                entity.HasIndex(e => e.NumEtage, "NumEtage")
                    .IsUnique();

                entity.Property(e => e.IdEtage).HasColumnType("int(11)");

                entity.Property(e => e.NumEtage).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Facturation>(entity =>
            {
                entity.HasKey(e => e.IdFacturation)
                    .HasName("PRIMARY");

                entity.ToTable("facturations");

                entity.HasIndex(e => e.IdPrestation, "FK_Facturations_Prestations");

                entity.HasIndex(e => e.IdReservationSejour, "FK_Facturations_ReservationsSejours");

                entity.HasIndex(e => e.IdTypePaiement, "FK_Facturations_TypesPaiements");

                entity.Property(e => e.IdFacturation).HasColumnType("int(11)");

                entity.Property(e => e.IdPrestation).HasColumnType("int(11)");

                entity.Property(e => e.IdReservationSejour).HasColumnType("int(11)");

                entity.Property(e => e.IdTypePaiement).HasColumnType("int(11)");

                entity.Property(e => e.NumFacture).HasMaxLength(50);

                entity.Property(e => e.QuantitePrestation).HasColumnType("int(11)");

                entity.HasOne(d => d.IdPrestationNavigation)
                    .WithMany(p => p.Facturations)
                    .HasForeignKey(d => d.IdPrestation)
                    .HasConstraintName("FK_Facturations_Prestations");

                entity.HasOne(d => d.IdReservationSejourNavigation)
                    .WithMany(p => p.Facturations)
                    .HasForeignKey(d => d.IdReservationSejour)
                    .HasConstraintName("FK_Facturations_ReservationsSejours");

                entity.HasOne(d => d.IdTypePaiementNavigation)
                    .WithMany(p => p.Facturations)
                    .HasForeignKey(d => d.IdTypePaiement)
                    .HasConstraintName("FK_Facturations_TypesPaiements");
            });

            modelBuilder.Entity<Fidelite>(entity =>
            {
                entity.HasKey(e => e.IdFidelite)
                    .HasName("PRIMARY");

                entity.ToTable("fidelites");

                entity.Property(e => e.IdFidelite).HasColumnType("int(11)");

                entity.Property(e => e.LibelleFidelite).HasMaxLength(50);
            });

            modelBuilder.Entity<HistoriqueActionsReservation>(entity =>
            {
                entity.HasKey(e => e.IdHistoriqueActionsReservation)
                    .HasName("PRIMARY");

                entity.ToTable("historiqueactionsreservations");

                entity.HasIndex(e => e.IdEmploye, "FK_HistoriqueActionsReservations_Employes");

                entity.HasIndex(e => e.IdReservationSejour, "FK_HistoriqueActionsReservations_ReservationsSejours");

                entity.Property(e => e.IdHistoriqueActionsReservation).HasColumnType("int(11)");

                entity.Property(e => e.IdEmploye).HasColumnType("int(11)");

                entity.Property(e => e.IdReservationSejour).HasColumnType("int(11)");

                entity.HasOne(d => d.IdEmployeNavigation)
                    .WithMany(p => p.Historiqueactionsreservations)
                    .HasForeignKey(d => d.IdEmploye)
                    .HasConstraintName("FK_HistoriqueActionsReservations_Employes");

                entity.HasOne(d => d.IdReservationSejourNavigation)
                    .WithMany(p => p.Historiqueactionsreservations)
                    .HasForeignKey(d => d.IdReservationSejour)
                    .HasConstraintName("FK_HistoriqueActionsReservations_ReservationsSejours");
            });

            modelBuilder.Entity<HistoriqueChambre>(entity =>
            {
                entity.HasKey(e => e.IdHistoriqueChambre)
                    .HasName("PRIMARY");

                entity.ToTable("historiquechambres");

                entity.HasIndex(e => e.IdChambre, "FK_HistoriqueChambres_Chambres");

                entity.HasIndex(e => e.IdReservationSejour, "FK_HistoriqueChambres_ReservationsSejours");

                entity.Property(e => e.IdHistoriqueChambre).HasColumnType("int(11)");

                entity.Property(e => e.IdChambre).HasColumnType("int(11)");

                entity.Property(e => e.IdReservationSejour).HasColumnType("int(11)");

                entity.HasOne(d => d.IdChambreNavigation)
                    .WithMany(p => p.Historiquechambres)
                    .HasForeignKey(d => d.IdChambre)
                    .HasConstraintName("FK_HistoriqueChambres_Chambres");

                entity.HasOne(d => d.IdReservationSejourNavigation)
                    .WithMany(p => p.Historiquechambres)
                    .HasForeignKey(d => d.IdReservationSejour)
                    .HasConstraintName("FK_HistoriqueChambres_ReservationsSejours");
            });

            modelBuilder.Entity<HistoriquesNettoyage>(entity =>
            {
                entity.HasKey(e => e.IdHistoriquesNettoyage)
                    .HasName("PRIMARY");

                entity.ToTable("historiquesnettoyages");

                entity.HasIndex(e => e.IdChambre, "FK_HistoriquesNettoyages_Chambres");

                entity.HasIndex(e => e.IdEmploye, "FK_HistoriquesNettoyages_Employes");

                entity.Property(e => e.IdHistoriquesNettoyage).HasColumnType("int(11)");

                entity.Property(e => e.IdChambre).HasColumnType("int(11)");

                entity.Property(e => e.IdEmploye).HasColumnType("int(11)");

                entity.HasOne(d => d.IdChambreNavigation)
                    .WithMany(p => p.Historiquesnettoyages)
                    .HasForeignKey(d => d.IdChambre)
                    .HasConstraintName("FK_HistoriquesNettoyages_Chambres");

                entity.HasOne(d => d.IdEmployeNavigation)
                    .WithMany(p => p.Historiquesnettoyages)
                    .HasForeignKey(d => d.IdEmploye)
                    .HasConstraintName("FK_HistoriquesNettoyages_Employes");
            });

            modelBuilder.Entity<Particulier>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("particuliers");

                entity.HasIndex(e => e.IdFidelite, "FK_Particuliers_Fidelites");

                entity.HasIndex(e => e.NumParticulier, "NumParticulier")
                    .IsUnique();

                entity.Property(e => e.IdClient).HasColumnType("int(11)");

                entity.Property(e => e.IdFidelite).HasColumnType("int(11)");

                entity.Property(e => e.NumParticulier).HasColumnType("int(11)");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithOne(p => p.Particulier)
                    .HasForeignKey<Particulier>(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Particuliers_Clients");

                entity.HasOne(d => d.IdFideliteNavigation)
                    .WithMany(p => p.Particuliers)
                    .HasForeignKey(d => d.IdFidelite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Particuliers_Fidelites");
            });

            modelBuilder.Entity<PossessionsEquipement>(entity =>
            {
                entity.HasKey(e => e.IdPossessionsEquipement)
                    .HasName("PRIMARY");

                entity.ToTable("possessionsequipements");

                entity.HasIndex(e => e.IdChambre, "FK_PossessionsEquipements_Chambres");

                entity.HasIndex(e => e.IdEquipementChambre, "FK_PossessionsEquipements_EquipementsChambres");

                entity.Property(e => e.IdPossessionsEquipement).HasColumnType("int(11)");

                entity.Property(e => e.IdChambre).HasColumnType("int(11)");

                entity.Property(e => e.IdEquipementChambre).HasColumnType("int(11)");

                entity.HasOne(d => d.IdChambreNavigation)
                    .WithMany(p => p.Possessionsequipements)
                    .HasForeignKey(d => d.IdChambre)
                    .HasConstraintName("FK_PossessionsEquipements_Chambres");

                entity.HasOne(d => d.IdEquipementChambreNavigation)
                    .WithMany(p => p.Possessionsequipements)
                    .HasForeignKey(d => d.IdEquipementChambre)
                    .HasConstraintName("FK_PossessionsEquipements_EquipementsChambres");
            });

            modelBuilder.Entity<Prestation>(entity =>
            {
                entity.HasKey(e => e.IdPrestation)
                    .HasName("PRIMARY");

                entity.ToTable("prestations");

                entity.Property(e => e.IdPrestation).HasColumnType("int(11)");

                entity.Property(e => e.LibellePrestation).HasMaxLength(100);

                entity.Property(e => e.PrixPrestation).HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<ReservationsSejour>(entity =>
            {
                entity.HasKey(e => e.IdReservationSejour)
                    .HasName("PRIMARY");

                entity.ToTable("reservationssejours");

                entity.HasIndex(e => e.IdClient, "FK_ReservationsSejours_Clients");

                entity.Property(e => e.IdReservationSejour).HasColumnType("int(11)");

                entity.Property(e => e.DateDebutReservationSejour).HasColumnType("date");

                entity.Property(e => e.DateFinReservationSejour).HasColumnType("date");

                entity.Property(e => e.IdClient).HasColumnType("int(11)");

                entity.Property(e => e.NbChambres).HasColumnType("int(11)");

                entity.Property(e => e.NbPersonnes).HasColumnType("int(11)");

                entity.Property(e => e.NumReservationSejour).HasColumnType("int(11)");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Reservationssejours)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationsSejours_Clients");
            });

            modelBuilder.Entity<StatutsChambre>(entity =>
            {
                entity.HasKey(e => e.IdStatutChambre)
                    .HasName("PRIMARY");

                entity.ToTable("statutschambres");

                entity.Property(e => e.IdStatutChambre).HasColumnType("int(11)");

                entity.Property(e => e.LibelleStatutChambre).HasMaxLength(50);
            });

            modelBuilder.Entity<TypesChambre>(entity =>
            {
                entity.HasKey(e => e.IdTypeChambre)
                    .HasName("PRIMARY");

                entity.ToTable("typeschambres");

                entity.Property(e => e.IdTypeChambre).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypeChambre).HasMaxLength(50);

                entity.Property(e => e.PrixChambre).HasColumnType("decimal(15,2)");
            });

            modelBuilder.Entity<TypesEmploye>(entity =>
            {
                entity.HasKey(e => e.IdTypeEmploye)
                    .HasName("PRIMARY");

                entity.ToTable("typesemployes");

                entity.Property(e => e.IdTypeEmploye).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypeEmploye).HasMaxLength(50);
            });

            modelBuilder.Entity<TypesPaiement>(entity =>
            {
                entity.HasKey(e => e.IdTypePaiement)
                    .HasName("PRIMARY");

                entity.ToTable("typespaiements");

                entity.Property(e => e.IdTypePaiement).HasColumnType("int(11)");

                entity.Property(e => e.LibelleTypePaiement).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
