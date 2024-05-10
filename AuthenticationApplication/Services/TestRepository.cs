using AuthenticationApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AuthenticationApplication.Services
{
    public class TestRepository : ITestRepository
    {

        private readonly IMongoCollection<ProductDto> _productCollection;

        public TestRepository(
            IOptions<DBConfiguration> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.MongodbConnectionstring);

            var mongoDatabase = mongoClient.GetDatabase(
                DatabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<ProductDto>(
                DatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<List<ProductDto>> GetAll() =>
          await _productCollection.Find(_ => true).ToListAsync();

        public async Task<ProductDto?> GetById(string id) =>
            await _productCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task Create(ProductDto newProductDto) =>
            await _productCollection.InsertOneAsync(newProductDto);

        public async Task Update(string id, ProductDto updatedProductDto) =>
            await _productCollection.ReplaceOneAsync(x => x._id == id, updatedProductDto);

        public async Task Remove(string id)
        {
            await _productCollection.DeleteOneAsync(x => x._id == id);
        }
    }
}
