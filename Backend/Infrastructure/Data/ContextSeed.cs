using Core.Entities.Identity;
using Core.Entities.OrderAggregate.Helpers;
using Core.Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ContextSeed
    {
        public static async Task SeedAsync(DataContext context, UserManager<AppUser> userManager, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = await File.ReadAllTextAsync("SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync("SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dmData = await File.ReadAllTextAsync("SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!userManager.Users.Any())
                {
                    var user = new AppUser
                    {
                        DisplayName = "Bob",
                        Email = "bob@letsshop.com",
                        UserName = "bob@letsshop.com",
                        Address = new Address
                        {
                            FirstName = "Bob",
                            LastName = "Bobbity",
                            Street = "10 The street",
                            City = "New York",
                            State = "NY",
                            ZipCode = "90210"
                        }
                    };

                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
