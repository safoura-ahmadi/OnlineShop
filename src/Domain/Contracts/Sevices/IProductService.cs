using Domain.Entiteis;
using Domain.ModelView;
using Domain.Utilities;

namespace Domain.Contracts.Sevices;

public interface IProductService
{
    List<GetProductDTO> GetAll();
    public Result Edit(int id, string name, decimal price, int quantity, int categoryId);
    string Delete(int id);
    Result Add(string name, decimal price, int quantity, int categoryId);
    Product? Get(int id);
}
