using KargoTakip.Server.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace KargoTakip.Server.WebAPI;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                AppUser user = new()
                {
                    Id = Guid.Parse("a9b67e56-d7c9-44f9-942d-6f774d28e786"),
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Taner",
                    LastName = "Saydam",
                    EmailConfirmed = true,
                    CreateAt = DateTimeOffset.Now,
                };

                user.CreateUserId = user.Id;

                userManager.CreateAsync(user, "1").Wait();


            }
        }
    }
}
