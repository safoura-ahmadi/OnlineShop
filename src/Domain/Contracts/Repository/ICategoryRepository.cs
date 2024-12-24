using Domain.Entiteis;
using Domain.ModelView;

namespace Domain.Contracts.Repository;

public interface ICategoryRepository
{
    List<GetCategoryDTO> GetAll();
    bool Create(string categoryName);
    bool Delete(int id);
    bool Update(Category category);
    Category? Get(int id);
    bool IsExist(int id);
}
