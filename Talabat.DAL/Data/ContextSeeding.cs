using System.Text.Json;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class ContextSeeding
    {
        public async static Task SeedAsync(ApplicationDbContext context)
        {


            try
            {

                if (context.Brands.Count() == 0)
                {

                    var BrandData = await File.ReadAllTextAsync("E:\\ProjectApi\\Talabat.DigiCrafterz.Solution\\Talabat.DAL\\Data\\Seeding\\brands.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(BrandData);


                    if (brands?.Count() > 0)
                    {

                        brands = brands.Select(b => new Brand()
                        {
                            Id = Guid.NewGuid(),
                            Name = b.Name,
                        }).ToList();


                        foreach (var brand in brands)
                        {
                            await context.Set<Brand>().AddAsync(brand);
                        }
                    }
                }

                if (context.Categories.Count() == 0)
                {
                    var CategoryData = await File.ReadAllTextAsync("E:\\ProjectApi\\Talabat.DigiCrafterz.Solution\\Talabat.DAL\\Data\\Seeding\\categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(CategoryData);
                    if (categories?.Count() > 0)
                    {

                        categories = categories.Select(b => new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = b.Name,
                        }).ToList();

                        foreach (var category in categories)
                        {
                            await context.Set<Category>().AddAsync(category);
                        }
                    }
                }

                if (!context.Products.Any())
                {
                    var ProductData = await File.ReadAllTextAsync("E:\\ProjectApi\\Talabat.DigiCrafterz.Solution\\Talabat.DAL\\Data\\Seeding\\Products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                    if (Products?.Count() > 0)
                    {

                        Products = Products.Select(p => new Product()
                        {
                            Id = Guid.NewGuid(),
                            Description = p.Description,
                            BrandId = p.BrandId,
                            CategoryId = p.CategoryId,
                            Price = p.Price,
                            PictureUrl = p.PictureUrl,
                            ProductName = p.ProductName,

                        }).ToList();

                        foreach (var product in Products)
                        {
                            await context.Set<Product>().AddAsync(product);
                        }
                    }



                }




                await context.SaveChangesAsync();


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Seeding failed: {ex.Message}");


            }

        }

    }
}
