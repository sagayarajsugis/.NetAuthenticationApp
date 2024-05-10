using AuthenticationApplication.Models;
using AuthenticationApplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private ITestRepository _repository;


        public HomeController(ITestRepository testRepository)
        {
            _repository = testRepository;
        }


        [HttpPost]
        public async Task CreateProduct(ProductDto productDto)
        {
            await _repository.Create(productDto);
        }
        [HttpGet]
        public async  Task<List<ProductDto>> GetAllProducts( )
        {
            return await _repository.GetAll();
        }
    }
}
