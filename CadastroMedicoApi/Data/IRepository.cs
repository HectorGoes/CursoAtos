using System.Threading.Tasks;
using CadastroMedicoApi.Models;

namespace CadastroMedicoApi.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();


        // MEDICO
        Task<MedicoModel[]> GetAllMedicoModelAsync (bool includeMedico);
        Task<MedicoModel[]> GetAllMedicoModelByEspecialidadeId (int EspecialidadeId, bool includeEspecialidade);
        Task<MedicoModel> GetMedicoModelById (int medicoId, bool includeCidade);

        //CIDADE
        Task<CidadeModel[]> GetAllCidadeModelAsync (bool includeCidade);
        //Task<MedicoModel[]> GetAllCidadeModelByEspecialidadeId (int EspecialidadeId, bool includeEspecialidade);
        Task<CidadeModel> GetCidadeModelById (int cidadeId, bool includeMedico);

        //USUARIO
        Task<UsuarioModel[]> GetAllUsuarioModelAsync(bool includeUsuario);
        Task<UsuarioModel> GetUsuarioModelById(int usuarioId, bool includeUsuario);
    }
}