using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ===== DbSets =====
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoPasaje> TiposPasaje { get; set; }
        public DbSet<TipoPasajero> TiposPasajero { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Correlativo> Correlativos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== Cliente =====
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(e => e.IdCliente);
            });

            // ===== Usuario =====
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(e => e.IdUsuario);
            });

            // ===== TipoPasaje =====
            modelBuilder.Entity<TipoPasaje>(entity =>
            {
                entity.ToTable("TipoPasaje");
                entity.HasKey(e => e.IdTipoPasaje);

                entity.HasData(
                    new TipoPasaje { IdTipoPasaje = 1, Nombre = "Economico" },
                    new TipoPasaje { IdTipoPasaje = 2, Nombre = "Ejecutivo" },
                    new TipoPasaje { IdTipoPasaje = 3, Nombre = "Primera Clase" }
                );
            });

            // ===== TipoPasajero =====
            modelBuilder.Entity<TipoPasajero>(entity =>
            {
                entity.ToTable("TipoPasajero");
                entity.HasKey(e => e.IdTipoPasajero);

                entity.HasData(
                    new TipoPasajero { IdTipoPasajero = 1, Nombre = "Adulto" },
                    new TipoPasajero { IdTipoPasajero = 2, Nombre = "Joven" },
                    new TipoPasajero { IdTipoPasajero = 3, Nombre = "Niño" },
                    new TipoPasajero { IdTipoPasajero = 4, Nombre = "Bebé" }
                );
            });

            // ===== Ciudad =====
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");
                entity.HasKey(c => c.IdCiudad);

                entity.HasOne(c => c.Pais)
                      .WithMany(p => p.Ciudades)
                      .HasForeignKey(c => c.IdPais)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ===== Pais =====
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("Pais");
                entity.HasKey(p => p.IdPais);
            });

            // ===== MetodoPago =====
            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.ToTable("MetodoPago");
                entity.HasKey(e => e.IdMetodoPago);

                entity.HasData(
                    new MetodoPago { IdMetodoPago = 1, Nombre = "Efectivo" },
                    new MetodoPago { IdMetodoPago = 2, Nombre = "Tarjeta Débito" },
                    new MetodoPago { IdMetodoPago = 3, Nombre = "Tarjeta Crédito" }
                );
            });

            // ===== Reserva =====
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");
                entity.HasKey(e => e.IdReserva);

                entity.HasOne(r => r.Cliente)
                      .WithMany()
                      .HasForeignKey(r => r.IdCliente)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.TipoPasaje)
                      .WithMany()
                      .HasForeignKey(r => r.IdTipoPasaje)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.TipoPasajero)
                      .WithMany()
                      .HasForeignKey(r => r.IdTipoPasajero)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.CiudadOrigen)
                      .WithMany()
                      .HasForeignKey(r => r.IdCiudadOrigen)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.CiudadDestino)
                      .WithMany()
                      .HasForeignKey(r => r.IdCiudadDestino)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");
                entity.HasKey(f => f.IdFactura);

                entity.HasOne(f => f.Cliente)
                      .WithMany()
                      .HasForeignKey(f => f.IdCliente)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.MetodoPago)
                      .WithMany()
                      .HasForeignKey(f => f.IdMetodoPago)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Reserva)
                      .WithMany()
                      .HasForeignKey(f => f.IdReserva)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ===== Correlativo =====
            modelBuilder.Entity<Correlativo>(entity =>
            {
                entity.ToTable("Correlativo");
                entity.HasKey(c => c.IdCorrelativo);

                entity.HasData(
                    new Correlativo
                    {
                        IdCorrelativo = 1,
                        TipoDocumento = "FACTURA",
                        UltimoNumero = 0
                    }
                );
            });


        }
    }
}