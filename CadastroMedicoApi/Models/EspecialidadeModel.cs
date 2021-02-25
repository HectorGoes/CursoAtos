using System.Collections.Generic;

namespace CadastroMedicoApi.Models
{
    public class EspecialidadeModel
    {
        public EspecialidadeModel()
        { }

        public EspecialidadeModel(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<MedicoEspecialidade> MedicoEspecialidade { get; set;}
        
        
    }
}