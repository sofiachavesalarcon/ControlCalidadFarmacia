using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;
using ControlCalidadFarmacia.Repositories;

namespace ControlCalidadFarmacia.Services
{
    public interface ITypeTestService
    {
        Task<List<TypeTest>> GetAll();
        Task<TypeTest> GetTypeTest(int idType);
        Task<TypeTest> CreateTypeTest(string name);
        Task<TypeTest> UpdateTypeTest(int id, string name);
        //Task<TypeTest> DeleteTypeTest(int id);
    }
    public class TypeTestService:ITypeTestService
    {
        private readonly ITypeTestRepository _typeTestRepository;


        public TypeTestService(ITypeTestRepository typeTestRepository)
        {
            _typeTestRepository = typeTestRepository;
        }
        public async Task<TypeTest> CreateTypeTest(string name)
        {
            return await _typeTestRepository.CreateTypeTest(name);
        }
        public async Task<List<TypeTest>> GetAll()
        {
            return await _typeTestRepository.GetAll();
        }
        public async Task<TypeTest> GetTypeTest(int idType)
        {
            return await _typeTestRepository.GetTypeTest(idType);
        }
        public async Task<TypeTest> UpdateTypeTest(int id, string? name = null)
        {
            TypeTest newType = await _typeTestRepository.GetTypeTest(id);
            if (newType != null)
            {
                if(name != null)
                {
                    newType.TypeName = name;
                }
                return await _typeTestRepository.UpdateTypeTest(newType);
            }
            throw new NotImplementedException();
        }
        //public async Task<TypeTest> DeleteTypeTest(int id)
        //{
        //    TypeTest typeTest = await _typeTestRepository.GetTypeTest(id);
        //    typeTest.IsDeleted = true;
        //    typeTest.Date = DateTime.Now;
        //    typeTest.ModifiedBy = Userapp;
        //    return await _typeTestRepository.DeleteTypeTest(typeTest);
        //}
    }
}
