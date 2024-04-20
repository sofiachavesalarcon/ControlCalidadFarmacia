using ControlCalidadFarmacia.Model;
using ControlCalidadFarmacia.Repositories;

namespace ControlCalidadFarmacia.Services
{
    public interface ILaboratoryService
    {
        Task<List<Laboratory>> GetAll();
        Task<Laboratory> GetLaboratory(int IdLaboratory);
        Task<Laboratory> CreateLaboratory(string name, string addres, string email);
        Task<Laboratory> UpdateLaboratory(int id, string name, string addres, string email);
        //Task<Laboratory> DeleteLaboratory(int id);


    }
    public class LaboratoryService: ILaboratoryService
    {
        private readonly ILaboratoryRepository _laboratoryRepository;


        public LaboratoryService(ILaboratoryRepository laboratoryRepository)
        {
            _laboratoryRepository = laboratoryRepository;
        }
        public async Task<Laboratory> CreateLaboratory(string name, string addres, string email)
        {
            return await _laboratoryRepository.CreateLaboratory(name, addres, email);
        }
        public async Task<List<Laboratory>> GetAll()
        {
            return await _laboratoryRepository.GetAll();
        }
        public async Task<Laboratory> GetLaboratory(int idLaboratory)
        {
            return await _laboratoryRepository.GetLaboratory(idLaboratory);
        }
        public async Task<Laboratory> UpdateLaboratory(int id, string? name = null, string? addres = null, string? email = null)
        {
            Laboratory newLaboratory = await _laboratoryRepository.GetLaboratory(id);
            if (newLaboratory != null)
            {
                if(name != null)
                {
                    newLaboratory.LaboratoryName = name;
                }
                if(addres != null)
                {
                    newLaboratory.Addres = addres;
                }
                if(email != null)
                {
                    newLaboratory.Email = email;
                }
                return await _laboratoryRepository.UpdateLaboratory(newLaboratory);
            }
            throw new NotImplementedException();
        }
        //public async Task<Laboratory> DeleteLaboratory(int id)
        //{
        //    Laboratory laboratory = await _laboratoryRepository.GetLaboratory(id);
        //    laboratory.IsDeleted = true;
        //    laboratory.Date = DateTime.Now;
        //    laboratory.ModifiedBy = Userapp;
        //    return await _laboratoryRepository.DeleteLaboratory(laboratory);
        //}
    }
}

