using Domain.Contracts.Repository;
using Domain.Entiteis;
using Domain.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductEfRepository : IProductRepository
{
    private readonly ShopDbContext _context;
    public ProductEfRepository()
    {
        _context = new ShopDbContext();
    }

    public bool Create(Product product)
    {
        try
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var item = _context.Products.First(p => p.Id == id);
            _context.Products.Remove(item);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Product? Get(int id)
    {
        return _context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }

    public List<GetProductDTO> GetAll()
    {
        return [.. _context.Products.AsNoTracking()
            .Include(p => p.Category)
            .Select(p => new GetProductDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryName = p.Category.Name
            })];
    }

    public bool Update(Product product)
    {
        try
        {
            var item = _context.Products.First(p => p.Id ==product.Id);
            item.Name = product.Name;
            item.Price = product.Price;
            item.Quantity = product.Quantity;
            item.CategoryId = product.CategoryId;
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
