using Wellness.Domain.Entities;
using Wellness.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Wellness.Persistence.Seed
{
    public static class DefaultDataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedTenantAsync(context);

            await SeedRolesAsync(context);

            await SeedPermissionsAsync(context);

            await SeedRolePermissionsAsync(context);

            await SeedAdminUserAsync(context);
            await SeedUserRole(context);
        }
        private static async Task SeedTenantAsync(
        ApplicationDbContext context)
        {
            if (await context.Tenants.AnyAsync())
            {
                return;
            }
            var tenant = new Tenant
            {
                Name = "Wellness Default Tenant",

                Domain = "wellness.local",

                IsActive = true
            };

            await context.Tenants.AddAsync(tenant);

            await context.SaveChangesAsync();
        }

        private static async Task SeedRolesAsync(
            ApplicationDbContext context)
        {
            if (await context.Roles.AnyAsync())
            {
                return;
            }

            var roles = new List<Role>
        {
            new()
            {
                Name = "Admin"
            },

            new()
            {
                Name = "Coach"
            },

            new()
            {
                Name = "User"
            }
        };

            await context.Roles.AddRangeAsync(roles);

            await context.SaveChangesAsync();
        }

        private static async Task SeedPermissionsAsync(
            ApplicationDbContext context)
        {
            if (await context.Permissions.AnyAsync())
            {
                return;
            }

            var permissions = new List<Permission>
        {
            new()
            {
                Name = "ManageUsers"
            },

            new()
            {
                Name = "ManageRoles"
            },

            new()
            {
                Name = "ManageHabits"
            },

            new()
            {
                Name = "ManageJournal"
            },

            new()
            {
                Name = "ManageWeight"
            },

            new()
            {
                Name = "ManageNotifications"
            },

            new()
            {
                Name = "ManageAI"
            }
        };

            await context.Permissions
                .AddRangeAsync(permissions);

            await context.SaveChangesAsync();
        }

        private static async Task SeedRolePermissionsAsync(
            ApplicationDbContext context)
        {
            if (await context.RolePermissions.AnyAsync())
            {
                return;
            }

            var adminRole = await context.Roles
                .FirstAsync(x => x.Name == "Admin");

            var permissions = await context.Permissions
                .ToListAsync();

            var rolePermissions =
                permissions.Select(permission =>
                    new RolePermission
                    {
                        RoleId = adminRole.Id,

                        PermissionId = permission.Id
                    }).ToList();

            await context.RolePermissions
                .AddRangeAsync(rolePermissions);

            await context.SaveChangesAsync();
        }

        private static async Task SeedAdminUserAsync(ApplicationDbContext context)
        {
            var existingAdmin = await context.Users.FirstOrDefaultAsync(x => x.Email == "admin@wellness.com");

            if (existingAdmin != null)
            {
                return;
            }

            var tenant = await context.Tenants
                .FirstAsync();

            var adminRole = await context.Roles
                .FirstAsync(x => x.Name == "Admin");

            var adminUser = new User
            {
                FirstName = "System",

                LastName = "Admin",

                Email = "admin@wellness.com",


                PhoneNumber = "9999999999",

                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),

                Language = "en",

                IsActive = true,

                TenantId = tenant.Id
            };

            await context.Users.AddAsync(adminUser);

            await context.SaveChangesAsync();
        }
        private static async Task SeedUserRole(ApplicationDbContext context)
        {
            var adminUser = await context.Users
                .FirstOrDefaultAsync(
                    x => x.Email == "admin@wellness.com");

            if (adminUser == null)
            {
                return;
            }

            var adminRole = await context.Roles
                .FirstAsync(x => x.Name == "Admin");

            var exists =
                await context.UserRoles.AnyAsync(
                    x =>
                        x.UserId == adminUser.Id &&
                        x.RoleId == adminRole.Id);

            if (exists)
            {
                return;
            }

            var userRole = new UserRole
            {
                UserId = adminUser.Id,

                RoleId = adminRole.Id
            };

            await context.UserRoles.AddAsync(userRole);

            await context.SaveChangesAsync();
        }
    }
}