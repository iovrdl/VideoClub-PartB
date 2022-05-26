using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using VideoClub.Core.Entities;

namespace VideoClub.Infrastructure.Data
{
    public class VideoClubDbContext : IdentityDbContext<User>
    {
        public VideoClubDbContext() : base("VideoClubContext", throwIfV1Schema: false)
        {}

        public static VideoClubDbContext Create()
        {
            return new VideoClubDbContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasMany(c => c.Rentals)
                .WithRequired(r => r.Customer)
                .WillCascadeOnDelete(false);

            builder.Entity<Favorite>()
                .HasKey(f => new { f.CustomerId, f.Genre })
                .HasRequired(f => f.Customer);

            builder.Entity<Film>()
                .HasMany(f => f.Copies)
                .WithRequired(c => c.Film)
                .WillCascadeOnDelete(false);

            builder.Entity<Copy>()
                .HasRequired(c => c.Film);

            builder.Entity<Rental>()
                .HasRequired(r => r.Customer)
                .WithMany(c => c.Rentals)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(builder);
        }
    }
}