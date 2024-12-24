using Domain.Entiteis;
using Domain.ModelView;

namespace Domain.Contracts.Repository;

public interface IProductRepository
{
    List<GetProductDTO> GetAll();
    bool Create(Product product);
    bool Delete(int id);
    bool Update(Product product);
    Product? Get(int id);
}
