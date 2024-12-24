using Domain.Contracts.Repository;
using Domain.Contracts.Sevices;
using Domain.Entiteis;
using Domain.ModelView;
using Domain.Utilities;
using System.Runtime.InteropServices;

namespace Domain.Services;

public class ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository) : IProductService
{
    private readonly IProductRepository _productrepo = productRepository;
    private readonly ICategoryRepository _categoryRepo = categoryRepository;

    public Result Add(string name, decimal price, int quantity, int categoryId)
    {
        if (!ValidationService.IsNameValid(name))
            return new Result(false, "نام وارد شده معتبر نیست.");
        if (!ValidationService.IsPriceValid(price))
            return new Result(false, "قیمت وارد شده معتبر نیست.");
        if (!ValidationService.IsQuantityValid(quantity))
            return new Result(false, "مقدار وارد شده معتبر نیست.");
        if (!_categoryRepo.IsExist(categoryId))
            return new Result(false, "دسته بندی وارد شده معتبر نیست.");
        var product = new Product()
        {
            Name = name,
            Price = price,
            Quantity = quantity,
            CategoryId = categoryId
        };
        var result = _productrepo.Create(product);
        if (result)
            return new Result(true, "محصول جدید با موفقیت ثبت شد.");
        else
            return new Result(false, "Something Wrong in Sql!");
    }

    public string Delete(int id)
    {
        var result = _productrepo.Delete(id);
        if (result)
            return "محصول با موفقیت حذف شد.";
        else
            return "Something Wrong in Sql!";

    }

    public Result Edit(int id, string name, decimal price, int quantity, int categoryId)
    {
        if (!ValidationService.IsNameValid(name))
            return new Result(false, "نام وارد شده معتبر نیست.");
        if (!ValidationService.IsPriceValid(price))
            return new Result(false, "قیمت وارد شده معتبر نیست.");
        if (!ValidationService.IsQuantityValid(quantity))
            return new Result(false, "مقدار وارد شده معتبر نیست.");
        if (!_categoryRepo.IsExist(categoryId))
            return new Result(false, "دسته بندی وارد شده معتبر نیست.");
        var product = new Product()
        {
            Id = id,
            Name = name,
            Price = price,
            Quantity = quantity,
            CategoryId = categoryId
        };
        var result = _productrepo.Update(product);
        if (result)
            return new Result(true, "ویرایش محصول با موفقیت انجام شد.");
        else
            return new Result(false, "Something Wrong in Sql!");
    }

    public Product? Get(int id)
    {
        var product = _productrepo.Get(id);
        if (product != null)
        {
            var category = _categoryRepo.Get(product.CategoryId);
            if (category != null)
            {
                product.CategoryName = category.Name;
            }

        }
        return product;

    }

    public List<GetProductDTO> GetAll()
    {
        return _productrepo.GetAll();
    }
}
