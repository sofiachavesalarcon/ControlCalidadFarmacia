using ControlCalidadFarmacia.Model;
using ControlCalidadFarmacia.Repositories;

namespace ControlCalidadFarmacia.Services
{
    public interface IProductService
    {
        Task<List<Products>> GetAll();
        Task<Products> GetProduct(int IdProduct);
        Task<Products> CreateProduct(string name, string description, DateTime Mdate, DateTime Edate);
        Task<Products> UpdateProduct(int id, string name, string description);
        //Task<Products> DeleteProduct(int id);
    }
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Products> CreateProduct(string name, string description, DateTime Mdate, DateTime Edate)
        {
            return await _productRepository.CreateProduct(name, description, Mdate, Edate);
        }
        public async Task<List<Products>> GetAll()
        {
            return await _productRepository.GetAll();
        }
        public async Task<Products> GetProduct(int idProduct)
        {
            return await _productRepository.GetProduct(idProduct);
        }
        public async Task<Products> UpdateProduct(int id, string? name = null, string? description = null)
        {
            Products newProduct = await _productRepository.GetProduct(id);
            if (newProduct != null)
            {
                if(name != null)
                {
                    newProduct.ProductName = name;
                }
                if (description != null)
                {
                    newProduct.ProductDescription = description;
                }
                return await _productRepository.UpdateProduct(newProduct);
            }
            throw new NotImplementedException();
        }
        //public async Task<Products> DeleteProduct(int id)
        //{
        //    Products product = await _productRepository.GetProduct(id);
        //    product.IsDeleted = true;
        //    product.Date = DateTime.Now;
        //    product.ModifiedBy = Userapp;
        //    return await _productRepository.DeleteProduct(product);
        //}
    }
}

