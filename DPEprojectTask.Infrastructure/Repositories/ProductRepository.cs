using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.Model.Products;
using DPEprojectTask.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DPEprojectTask.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task add(Product product)
        {
            await _appDbContext.products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Product> get(int Id)
        {
            var product = await _appDbContext.products.FirstOrDefaultAsync(x => x.Id == Id);
            return product;
        }

        public async Task Save(Product product)
        {
            _appDbContext.Update(product);
            //_appDbContext.Remove(product.Id);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
