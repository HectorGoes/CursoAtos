using System.Collections.Generic;

namespace CadastroMedicoApi.Models
{
    public class MedicoModel
    {
        public MedicoModel(){}
        public MedicoModel(int Id, string Nome, string Crm, string Telefone)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Crm = Crm;
            this.Telefone = Telefone;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<MedicoCidade> MedicoCidade { get; set;}
        public IEnumerable<MedicoEspecialidade> MedicoEspecialidade { get; set;}
    }
}