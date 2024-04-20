using ControlCalidadFarmacia.Context;
using ControlCalidadFarmacia.Model;
using Microsoft.EntityFrameworkCore;

namespace ControlCalidadFarmacia.Repositories
{
    public interface ILaboratoryRepository
    {
        Task<List<Laboratory>>GetAll();
        Task<Laboratory> GetLaboratory(int IdLaboratory);
        Task<Laboratory> CreateLaboratory(string name, string addres, string email);
        Task<Laboratory> UpdateLaboratory(Laboratory laboratory);
        //Task<Laboratory> DeleteLaboratory(Laboratory laboratory);

    }
    public class LaboratoryRepository: ILaboratoryRepository
    {
        private readonly pharmacyContext _db;
        public LaboratoryRepository(pharmacyContext db)
        {
            _db = db;
        }
        public async Task<Laboratory> CreateLaboratory(string name, string addres, string email)
        {
            Laboratory newLaboratory = new Laboratory
            {
                LaboratoryName = name,
                Addres = addres,
                Email = email
            };
            await _db.laboratorys.AddAsync(newLaboratory); 
            _db.SaveChanges();
            return newLaboratory;
        }
        public async Task<List<Laboratory>> GetAll()
        {
            return await _db.laboratorys.ToListAsync();
        }
        public async Task<Laboratory> GetLaboratory(int idLaboratory)
        {
            return await _db.laboratorys.FirstOrDefaultAsync(u => u.LaboratoryId == idLaboratory);
        }
        public async Task<Laboratory> UpdateLaboratory(Laboratory laboratory)
        {
            _db.laboratorys.Update(laboratory);
            await _db.SaveChangesAsync();
            return laboratory;
        }
        //public async Task<Laboratory> DeleteLaboratory(Laboratory laboratory)
        //{
        //    await _db.laboratorys.AddAsync(laboratory);
        //    _db.SaveChanges();
        //    return laboratory;
        //}

    }
}
