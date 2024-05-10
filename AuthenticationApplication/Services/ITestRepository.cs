using AuthenticationApplication.Models;

namespace AuthenticationApplication.Services
{
    public interface ITestRepository
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto?> GetById(string id);
        Task Create(ProductDto newProductDto);
        Task Update(string id, ProductDto updatedProductDto);

    }
}
