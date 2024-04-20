using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;
using Microsoft.EntityFrameworkCore;

namespace ControlCalidadFarmacia.Repositories
{
    public interface ITypeTestRepository
    {
        Task<List<TypeTest>> GetAll();
        Task<TypeTest> GetTypeTest(int idType);
        Task<TypeTest> CreateTypeTest(string name);
        Task<TypeTest> UpdateTypeTest(TypeTest typeTest);
        //Task<TypeTest> DeleteTypeTest(TypeTest typeTest);
    }
    public class TypeTestRepository: ITypeTestRepository
    {

        private readonly pharmacyContext _db;
        public TypeTestRepository(pharmacyContext db)
        {
            _db = db;
        }
        public async Task<TypeTest> CreateTypeTest(string name)
        {
            TypeTest newType = new TypeTest
            {
                TypeName= name  
            };
            await _db.typeTests.AddAsync(newType);
            _db.SaveChanges();
            return newType;
        }
        public async Task<List<TypeTest>> GetAll()
        {
            return await _db.typeTests.ToListAsync();
        }
        public async Task<TypeTest> GetTypeTest(int idType)
        {
            return await _db.typeTests.FirstOrDefaultAsync(u => u.TypeId == idType);
        }
        public async Task<TypeTest> UpdateTypeTest(TypeTest typeTest)
        {
            _db.typeTests.Update(typeTest);
            await _db.SaveChangesAsync();
            return typeTest;
        }
        //public async Task<TypeTest> DeleteTypeTest(TypeTest typeTest)
        //{
        //    await _db.typeTests.AddAsync(typeTest);
        //    _db.SaveChanges();
        //    return typeTest;
        //}
    }

}
