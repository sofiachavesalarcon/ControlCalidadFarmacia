using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;
using ControlCalidadFarmacia.Repositories;

namespace ControlCalidadFarmacia.Services
{
    public interface ITestService
    {
        Task<List<Tests>> GetAll();
        Task<Tests> GetTest(int idTest);
        Task<Tests> CreateTest(int IdProduct, int IdLaboratory, int IdType,string observations, DateTime dateTest);
        Task<Tests> UpdateTest(int id, int? IdProduct = null, int? IdLaboratory = null, int? IdType = null, string? observations = null);
        //Task<Tests> DeleteTest(int id);
    }
    public class TestService: ITestService
    {
        private readonly ITestRepository _testRepository;


        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<Tests> CreateTest(int IdProduct, int IdLaboratory, int IdType,string observations,DateTime dateTest)
        {
            return await _testRepository.CreateTest(IdProduct, IdLaboratory, IdType, observations, dateTest);
        }
        public async Task<List<Tests>> GetAll()
        {
            return await _testRepository.GetAll();
        }
        public async Task<Tests> GetTest(int idTest)
        {
            return await _testRepository.GetTest(idTest);
        }
        public async Task<Tests> UpdateTest(int id, int? IdProduct = null, int? IdLaboratory = null, int? IdType = null, string? observations = null)
        {
            Tests newTest = await _testRepository.GetTest(id);
            if (newTest != null)
            {
                if (IdProduct != null)
                {
                    newTest.ProductId = (int)IdProduct;
                }
                if (IdLaboratory != null)
                {
                    newTest.LaboratoryId = (int)IdLaboratory;
                }
                if (IdType != null)
                {
                    newTest.TypeId = (int)IdType;
                }

                if (observations != null)
                {
                    newTest.Observations = observations;
                }
                return await _testRepository.UpdateTest(newTest);
            }
            throw new NotImplementedException();
        }
        //public async Task<Tests> DeleteTest(int id)
        //{
        //    Tests test = await _testRepository.GetTest(id);
        //    test.IsDeleted = true;
        //    test.Date = DateTime.Now;
        //    test.ModifiedBy = Userapp;
        //    return await _testRepository.DeleteTest(test);
        //}

        
    }
}
