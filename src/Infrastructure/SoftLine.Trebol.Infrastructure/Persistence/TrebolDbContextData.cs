using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SoftLine.Trebol.Application.Models.Authorization;
using SoftLine.Trebol.Domain;
using System.Diagnostics.Metrics;

namespace SoftLine.Trebol.Infrastructure.Persistence;

public class TrebolDbContextData
{
    public static async Task LoadDataAsync(
        TrebolDbContext context,
        UserManager<User> usuarioManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory
    )
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(Role.USER));
            }

            if (!usuarioManager.Users.Any())
            {
                var usuarioAdmin = new User
                {
                    FirstName = "Sixto José",
                    LastName = "Romero Martínez",
                    Email = "sixto.jose@gmail.com",
                    UserName = "sixto.romero",
                    Phone = "3022415223",
                    AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24",
                };
                await usuarioManager.CreateAsync(usuarioAdmin, "PasswordSixtoRomero123$");
                await usuarioManager.AddToRoleAsync(usuarioAdmin, Role.ADMIN);

                var usuario = new User
                {
                    FirstName = "Deni Luz",
                    LastName = "Pastrana Hoyos",
                    Email = "deni.luz@gmail.com",
                    UserName = "deni.pastrana",
                    Phone = "3114585233",
                    AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d",
                };
                await usuarioManager.CreateAsync(usuario, "PasswordDeniLuz123$");
                await usuarioManager.AddToRoleAsync(usuario, Role.USER);
            }

            if (!context.Categories!.Any())
            {
                var categoryData = File.ReadAllText("../../Infrastructure/Ecommerce.Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                await context.Categories!.AddRangeAsync(categories!);
                await context.SaveChangesAsync();
            }

            if (!context.Products!.Any())
            {
                var productData = File.ReadAllText("../../Infrastructure/Ecommerce.Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                await context.Products!.AddRangeAsync(products!);
                await context.SaveChangesAsync();
            }

            if (!context.Images!.Any())
            {
                var imageData = File.ReadAllText("../../Infrastructure/Ecommerce.Infrastructure/Data/image.json");
                var imagenes = JsonConvert.DeserializeObject<List<Image>>(imageData);
                await context.Images!.AddRangeAsync(imagenes!);
                await context.SaveChangesAsync();
            }

            if (!context.Reviews!.Any())
            {
                var reviewData = File.ReadAllText("../../Infrastructure/Ecommerce.Infrastructure/Data/review.json");
                var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                await context.Reviews!.AddRangeAsync(reviews!);
                await context.SaveChangesAsync();
            }


            if (!context.Countries!.Any())
            {
                var countryData = File.ReadAllText("../../Infrastructure/Ecommerce.Infrastructure/Data/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                await context.Countries!.AddRangeAsync(countries!);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<TrebolDbContextData>();
            logger.LogError(e.Message);
        }

    }

}
