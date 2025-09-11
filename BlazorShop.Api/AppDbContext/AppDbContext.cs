using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BlazorShop.Api.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //ORM mapping
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Beauty", IconCss = "fas fa-spa" },
             new Category { Id = 2, Name = "Electronics", IconCss = "fas fa-tv" },
             new Category { Id = 4, Name = "Clothing", IconCss = "fas fa-tshirt" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Gloss",
                    Description = "Super Gloss of coconut",
                    ImageUrl = "Images/Beauty/Beauty.png",
                    Price = 100,
                    Quantity = 50,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Lipstick",
                    Description = "Red matte lipstick",
                    ImageUrl = "Images/Beauty/Lipstick.png",
                    Price = 80,
                    Quantity = 100,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Foundation",
                    Description = "Liquid foundation for all skin tones",
                    ImageUrl = "Images/Beauty/Foundation.png",
                    Price = 120,
                    Quantity = 70,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Perfume",
                    Description = "Vanilla fragrance perfume",
                    ImageUrl = "Images/Beauty/Perfume.png",
                    Price = 200,
                    Quantity = 40,
                    CategoryId = 1
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 5,
                    Name = "Smartphone",
                    Description = "5G smartphone with OLED screen",
                    ImageUrl = "Images/Electronics/Smartphone.png",
                    Price = 3500,
                    Quantity = 30,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Name = "Laptop",
                    Description = "Ultrabook 16GB RAM 512GB SSD",
                    ImageUrl = "Images/Electronics/Laptop.png",
                    Price = 5500,
                    Quantity = 20,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "Headphones",
                    Description = "Noise cancelling wireless headphones",
                    ImageUrl = "Images/Electronics/Headphones.png",
                    Price = 800,
                    Quantity = 60,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Smartwatch",
                    Description = "Waterproof smartwatch with GPS",
                    ImageUrl = "Images/Electronics/Smartwatch.png",
                    Price = 1200,
                    Quantity = 45,
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 13,
                    Name = "T-Shirt",
                    Description = "100% cotton white T-shirt",
                    ImageUrl = "Images/Clothing/TShirt.png",
                    Price = 60,
                    Quantity = 200,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 14,
                    Name = "Jeans",
                    Description = "Slim fit blue jeans",
                    ImageUrl = "Images/Clothing/Jeans.png",
                    Price = 180,
                    Quantity = 120,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 15,
                    Name = "Jacket",
                    Description = "Leather jacket black",
                    ImageUrl = "Images/Clothing/Jacket.png",
                    Price = 350,
                    Quantity = 50,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 16,
                    Name = "Sneakers",
                    Description = "Running sneakers with foam sole",
                    ImageUrl = "Images/Clothing/Sneakers.png",
                    Price = 400,
                    Quantity = 70,
                    CategoryId = 4
                }
            );

            modelBuilder.Entity<User>().HasData(new User
            {
                Id=1,
                Name = "Leonardo coutinho"
            });

        }
    }
}
