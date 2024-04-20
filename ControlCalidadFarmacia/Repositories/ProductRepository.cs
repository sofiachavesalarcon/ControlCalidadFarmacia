using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;
using Microsoft.EntityFrameworkCore;

namespace ControlCalidadFarmacia.Repositories
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAll();
        Task<Products> GetProduct(int IdProduct);
        Task<Products> CreateProduct(string name, string description, DateTime Mdate, DateTime Edate);
        Task<Products> UpdateProduct(Products products);
        //Task<Products> DeleteProduct(Products products);
    }
    public class ProductRepository: IProductRepository
    {
        private readonly pharmacyContext _db;
        public ProductRepository(pharmacyContext db)
        {
            _db = db;
        }
        public async Task<Products> CreateProduct(string name, string description, DateTime Mdate, DateTime Edate)
        {
            Products newProduct = new Products
            {
                ProductName = name,
                ProductDescription = description,
                ProductManufacturingDate = Mdate,
                ProductExpirationDate = Edate

            };
            await _db.products.AddAsync(newProduct);
            _db.SaveChanges();
            return newProduct;
        }
        public async Task<List<Products>> GetAll()
        {
            return await _db.products.ToListAsync();
        }
        public async Task<Products> GetProduct(int idProduct)
        {
            return await _db.products.FirstOrDefaultAsync(u => u.ProductId == idProduct);
        }
        public async Task<Products> UpdateProduct(Products products)
        {
            _db.products.Update(products);
            await _db.SaveChangesAsync();
            return products;
        }
        //public async Task<Products> DeleteProduct(Products product)
        //{
        //    await _db.products.AddAsync(product);
        //    _db.SaveChanges();
        //    return product;
        //}
    }
}

