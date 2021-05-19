﻿using CCN_Solution.ColisDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Extensions
{
    public static class BuilderExtension
    {
        public static void AddModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agence>(entity =>
            {
                entity.HasOne(a => a.Region)
                    .WithMany(a => a.Agences)
                    .HasForeignKey(a => a.RegionId);
            });

            modelBuilder.Entity<PrixVoyageRegion>(entity =>
            {
                entity.HasOne(p => p.RegionDepart)
                    .WithMany()
                    .HasForeignKey(p => p.RegionDepartId);

                entity.HasOne(p => p.RegionArrivee)
                    .WithMany()
                    .HasForeignKey(p => p.RegionArriveeId);
            });

            modelBuilder.Entity<Livraison>(entity =>
            {
                entity.HasOne(l => l.Colis)
                    .WithMany()
                    .HasForeignKey(l => l.ColisId);

                entity.HasOne(l => l.Livreur)
                    .WithMany()
                    .HasForeignKey(l => l.LivreurId);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasOne(c => c.Region)
                    .WithMany(c => c.Clients)
                    .HasForeignKey(c => c.RegionId);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasOne(i => i.Client)
                    .WithMany(i => i.Images)
                    .HasForeignKey(i => i.ClientId);
            });

            modelBuilder.Entity<Colis>(entity =>
            {
                entity.HasOne(c => c.AgenceDepart)
                    .WithMany()
                    .HasForeignKey(c => c.AgenceDepartId);
                entity.HasOne(c => c.AgenceRecepteur)
                    .WithMany()
                    .HasForeignKey(c => c.AgenceRecepteurId);

                entity.HasOne(c => c.RegionDepart)
                    .WithMany()
                    .HasForeignKey(c => c.RegionDepartId);
                entity.HasOne(c => c.RegionRecepteur)
                    .WithMany()
                    .HasForeignKey(c => c.RegionRecepteurId);

                entity.HasOne(c => c.TypeDeColis)
                    .WithMany()
                    .HasForeignKey(c => c.TypeDeColisId);

                entity.HasOne(c => c.ClientSource)
                    .WithMany()
                    .HasForeignKey(c => c.ClientSourceId);
                entity.HasOne(c => c.ClientRecepteur)
                    .WithMany()
                    .HasForeignKey(c => c.ClientRecepteurId);
            });

            modelBuilder.Entity<PrixVoyageRegion>(entity =>
            {
                entity.HasOne(p => p.RegionDepart)
                    .WithMany()
                    .HasForeignKey(p => p.RegionDepartId);

                entity.HasOne(p => p.RegionArrivee)
                    .WithMany()
                    .HasForeignKey(p => p.RegionArriveeId);
            });
        }
    }
}