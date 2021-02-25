namespace CadastroMedicoApi.Models
{
    public class MedicoCidade
    {
      public MedicoCidade(){}

    public MedicoCidade(int MedicoId, int CidadeId, MedicoModel Medico, CidadeModel Cidade)
    {
      this.MedicoId = MedicoId;
      this.CidadeId = CidadeId;
      this.Medico = Medico;
      this.Cidade = Cidade;

    }
    public int MedicoId { get; set; }
    public int CidadeId { get; set; }
    public MedicoModel Medico { get; set; }
    public CidadeModel Cidade { get; set; }
    
  }
}