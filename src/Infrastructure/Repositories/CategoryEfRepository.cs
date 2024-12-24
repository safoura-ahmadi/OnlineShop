using Domain.Contracts.Repository;
using Domain.Entiteis;
using Domain.ModelView;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Repositories;

public class CategoryEfRepository : ICategoryRepository
{
    private readonly ShopDbContext _context;
    public CategoryEfRepository()
    {
        _context = new ShopDbContext();
    }

    public bool Create(string categoryName)
    {
        var category = new Category()
        {
            Name = categoryName,
        };
        try
        {
            _context.Categories.Add(category);
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
            var item = _context.Categories.First(p => p.Id == id);
            _context.Categories.Remove(item);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Category? Get(int id)
    {
        return _context.Categories.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }

    public List<GetCategoryDTO> GetAll()
    {
        return [.. _context.Categories.AsNoTracking()
            .Select(c => new GetCategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
            })];
    }

    public bool IsExist(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }

    public bool Update(Category category)
    {
        try
        {
            var item = _context.Categories.First(c => c.Id == category.Id);
            item.Name = category.Name;
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
