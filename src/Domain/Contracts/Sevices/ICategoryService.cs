using Domain.Entiteis;
using Domain.ModelView;

namespace Domain.Contracts.Sevices;

public interface ICategoryService
{
    List<GetCategoryDTO> GetAll();
    string Add(string categoryName);
    string Delete(int id);
    string Edit(Category category);
    Category? Get(int id);
  
}
