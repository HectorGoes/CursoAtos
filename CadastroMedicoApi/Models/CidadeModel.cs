using System.Collections.Generic;

namespace CadastroMedicoApi.Models
{
    public class CidadeModel
    {
        public CidadeModel(){}
        public CidadeModel(int Id, string Nome, string Estado)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Estado = Estado;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public IEnumerable<MedicoCidade> MedicoCidade { get; set;}


    }
}