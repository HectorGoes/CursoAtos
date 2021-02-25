namespace CadastroMedicoApi.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(){

        }

        public UsuarioModel( int Id, string Usuario, string Login, string Senha, int Privilegio)
        {
            this.Id = Id;
            this.Usuario = Usuario;
            this.Login = Login;
            this.Senha = Senha;
            this.PrivilegioId = Privilegio;
        }
         public int Id { get; set; }
        public string Usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int PrivilegioId { get; set; }

    }
}