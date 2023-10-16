using DPEprojectTask.Domain.Model.Orders;
using DPEprojectTask.Domain.Model.Products;
using DPEprojectTask.Domain.Model.Tags;
using DPEprojectTask.Domain.Model.Users;
using DPEprojectTask.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DPEprojectTask.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;
        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<CustomIdentityUser> customIdentityUsers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Tag> tags { get; set; }

        public async Task<bool> SaveEntityAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatachDomainEventAsync(this);
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().ToTable("productCategories");
            modelBuilder.Entity<ProductCategory>().HasKey(t => t.Id);
            modelBuilder.Entity<ProductCategory>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductCategory>().HasData(
              new List<ProductCategory>()
              {
                    new ProductCategory(1,"Category 1","description 1"),
                    new ProductCategory(2,"Category 2","description 2"),
                    new ProductCategory(3,"Category 3","description 3"),
              });

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().HasKey(t => t.Id);
            modelBuilder.Entity<Product>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().HasData(
                new List<Product>()
                {
                    new Product(1 , "title 1" , "body 1" , DateTime.Now , 1000 , "image Path 1","file Path 1" , 1 , true , false , true),
                    new Product(2 , "title 2" , "body 2" , DateTime.Now , 2000 , "image Path 2","file Path 2" , 2 , true , false , false)

                });


            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().HasKey(t => t.Id);
            modelBuilder.Entity<Order>().Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().HasKey(t => t.Id);
            modelBuilder.Entity<Comment>().Property(t => t.Id).ValueGeneratedOnAdd();



            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().HasKey(t => t.Id);
            modelBuilder.Entity<Tag>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tag>().HasData(
                new List<Tag>()
                {
                    new Tag(1,"tag 1"),
                    new Tag(2,"tag 2"),
                    new Tag(3,"tag 3"),
                    new Tag(4,"tag 4"),
                    new Tag(5,"tag 5")
                });


            modelBuilder.Entity<CustomIdentityUser>().HasData(
                new List<CustomIdentityUser>()
                {
                    new CustomIdentityUser()
                    {
                            Id =1,
                            FirstName ="mmdrz",
                            LastName = "Sasani",
                            UserName = "mmdrz",
                            Location = "Location 1",
                            PhotoFileName = "Photo Name 1",
                            CreatedAt = DateTime.Now,
                            Email="mmdrz1988@gmail.com",
                            Mobile =34416296,
                            PhoneNumber = "09369406932",
                            PhoneNumberConfirmed =true,
                            LoginCount = 0,
                            PurchasedNumber =0,
                            IsActive =true,
                            TwoFactorEnabled =true,
                            IsEmailPublic =true,
                            LockoutEnabled =true,
                            AccessFailedCount =0,
                    }
                }) ;
        }

    }
}
