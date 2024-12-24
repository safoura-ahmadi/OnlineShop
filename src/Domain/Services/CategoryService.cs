using Domain.Contracts.Repository;
using Domain.Contracts.Sevices;
using Domain.Entiteis;
using Domain.ModelView;

namespace Domain.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo = categoryRepository;

    public string Add(string categoryName)
    {
        var result = _categoryRepo.Create(categoryName);
        if (!result)
            return "Something Wrong in Sql!";
        return "ثبت دسته بندی جدید با موفقیت انجام شد.";

    }

    public string Delete(int id)
    {
        var result = _categoryRepo.Delete(id);
        if (result)
            return "دسته بندی با موفقیت حذف شد.";
        else
            return "Something Wrong in Sql!";
    }

    public string Edit(Category category)
    {
       var result = _categoryRepo.Update(category);
        if (result)
            return "ویرایش دسته بندی با موفقیت انجام شد.";
        else
            return "Something Wrong in Sql!";
    }

    public Category? Get(int id)
    {
       return _categoryRepo.Get(id);
    }

    public List<GetCategoryDTO> GetAll()
    {
        return _categoryRepo.GetAll();
    }
}
