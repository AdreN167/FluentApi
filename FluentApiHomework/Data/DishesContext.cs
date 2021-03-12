using FluentApiHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApiHomework.Data
{
    public class DishesContext : DbContext
    {
        public DishesContext()
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishProduct> DishProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WW\\MSSQLSERVER2017; Database=FluentApiLesson; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(product => product.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<DishProduct>()
                .HasOne(product => product.Product)
                .WithMany(dishProducts => dishProducts.DishProducts);

            modelBuilder.Entity<DishProduct>()
                .HasOne(dish => dish.Dish)
                .WithMany(dishProducts => dishProducts.DishProducts);

            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(dish => dish.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Dish>()
                .HasKey(dish => dish.Id);

            modelBuilder.Entity<DishProduct>()
                .ToTable("dishProducts")
                .Property(dishProduct => dishProduct.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<DishProduct>()
                .HasKey(dishProduct => dishProduct.Id);

            

            /*modelBuilder.Entity<Dish>()
                .HasMany(dish => dish.Products)
                .WithMany(product => product.Dishes);*/




            base.OnModelCreating(modelBuilder);
        }
    }
}
