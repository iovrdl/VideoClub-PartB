using System;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VideoClub.Core.Entities;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VideoClubDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoClubDbContext context)
        {
            var adminRole = context.Roles.Add(new IdentityRole { Name = "Admin" });

            var hasher = new PasswordHasher();
            var adminUser = context.Users.Add(
                new User
                {
                    UserName = "default@default.com",
                    Email = "default@default.com",
                    PasswordHash = hasher.HashPassword("Pa$$w0rd"),
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            );

            adminUser.Roles.Add(new IdentityUserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            });

            base.Seed(context);
        }
    }
}