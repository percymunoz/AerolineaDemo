using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aerolinea.Models.Entidades
{
    public partial class ReservaVueloContext : DbContext
    {
        public ReservaVueloContext()
        {
        }

        public ReservaVueloContext(DbContextOptions<ReservaVueloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeropuerto> Aeropuerto { get; set; }
        public virtual DbSet<ClaseTarifaria> ClaseTarifaria { get; set; }
        public virtual DbSet<Pasajero> Pasajero { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Vuelo> Vuelo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PC-PERCY;Database=ReservaVuelo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Aeropuerto>(entity =>
            {
                entity.Property(e => e.AeropuertoId).HasColumnName("AeropuertoID");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoIata)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClaseTarifaria>(entity =>
            {
                entity.Property(e => e.ClaseTarifariaId).HasColumnName("ClaseTarifariaID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioBase).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Pasajero>(entity =>
            {
                entity.HasKey(x => x.PasajeroId);
                entity.Property(e => e.PasajeroId)
                    .HasColumnName("PasajeroID");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(x => x.ReservaId);
                entity.Property(e => e.ReservaId)
                    .HasColumnName("ReservaID");

                entity.Property(e => e.ClaseTarifariaId).HasColumnName("ClaseTarifariaID");

                entity.Property(e => e.FechaReserva).HasColumnType("datetime");

                entity.Property(e => e.PasajeroId).HasColumnName("PasajeroID");

                entity.Property(e => e.PrecioReservado).HasColumnType("smallmoney");

                entity.HasOne(d => d.ClaseTarifaria)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.ClaseTarifariaId)
                    .HasConstraintName("FK_Reserva_ClaseTarifaria");

                entity.HasOne(d => d.Pasajero)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.PasajeroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Pasajero");

                entity.HasOne(d => d.VueloIdaNavigation)
                    .WithMany(p => p.ReservaVueloIdaNavigation)
                    .HasForeignKey(d => d.VueloIda)
                    .HasConstraintName("FK_Reserva_Vuelo_Ida");

                entity.HasOne(d => d.VueloRetornoNavigation)
                    .WithMany(p => p.ReservaVueloRetornoNavigation)
                    .HasForeignKey(d => d.VueloRetorno)
                    .HasConstraintName("FK_Reserva_Vuelo_Retorno");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.Property(e => e.HoraLlegada).HasColumnType("time(0)");

                entity.Property(e => e.HoraSalida).HasColumnType("time(0)");

                entity.HasOne(d => d.AeropuertoDestinoNavigation)
                    .WithMany(p => p.VueloAeropuertoDestinoNavigation)
                    .HasForeignKey(d => d.AeropuertoDestino)
                    .HasConstraintName("FK_Vuelo_Aeropuerto_Destino");

                entity.HasOne(d => d.AeropuertoOrigenNavigation)
                    .WithMany(p => p.VueloAeropuertoOrigenNavigation)
                    .HasForeignKey(d => d.AeropuertoOrigen)
                    .HasConstraintName("FK_Vuelo_Aeropuerto_Origen");
            });
        }
    }
}
