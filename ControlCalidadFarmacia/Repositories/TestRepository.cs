using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;
using Microsoft.EntityFrameworkCore;


namespace ControlCalidadFarmacia.Repositories
{
    public interface ITestRepository
    {
        Task<List<Tests>> GetAll();
        Task<Tests> GetTest(int idTest);
        Task<Tests> CreateTest(int IdProduct, int IdLaboratory, int IdType, string observations, DateTime dateTest);
        Task<Tests> UpdateTest(Tests tests);
        //Task<Tests> DeleteTest(Tests tests);
    }
    public class TestRepository:ITestRepository
    {
        private readonly pharmacyContext _db;
        public TestRepository(pharmacyContext db)
        {
            _db = db;
        }
        public async Task<Tests> CreateTest(int IdProduct, int IdLaboratory, int IdType, string observations, DateTime dateTest)
        {
            Tests newTest = new Tests
            {
                ProductId = IdProduct,
                LaboratoryId = IdLaboratory,
                TypeId = IdType,
                Observations = observations,
                DateTest = dateTest

            };
            await _db.tests.AddAsync(newTest);
            _db.SaveChanges();
            return newTest;
        }
        public async Task<List<Tests>> GetAll()
        {
            return await _db.tests.ToListAsync();
        }
        public async Task<Tests> GetTest(int idTest)
        {
            return await _db.tests.FirstOrDefaultAsync(u => u.TestId == idTest);
        }
        public async Task<Tests> UpdateTest(Tests tests)
        {
            _db.tests.Update(tests);
            await _db.SaveChangesAsync();
            return tests;
        }
        //public async Task<Tests> DeleteTest(Tests tests)
        //{
        //    await _db.tests.AddAsync(tests);
        //    _db.SaveChanges();
        //    return tests;
        //}
    }
}
