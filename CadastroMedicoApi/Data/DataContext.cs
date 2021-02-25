using System.Collections.Generic;
using CadastroMedicoApi.Models;
using Microsoft.EntityFrameworkCore;


namespace CadastroMedicoApi.Data
{
    public class DataContext : DbContext 

    { 
        public DataContext(DbContextOptions<DataContext>
        options): base (options){}
        public DbSet<MedicoModel> Medicos {get; set;}
        public DbSet<CidadeModel> Cidades {get; set;}
        public DbSet<EspecialidadeModel> Especialidades {get; set;}
        public DbSet<UsuarioModel> Usuarios {get; set;}
        public DbSet<PrivilegioModel> Privilegios {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<MedicoModel>()
                .HasData(new List<MedicoModel>(){
                    new MedicoModel(1, "Zoro", "965669", "541231849"),
                    new MedicoModel(2, "Vegeta",  "968549", "321149366"),
                    new MedicoModel(3, "Asta",  "155459", "358949544"),
                    new MedicoModel(4, "Midoriya", "969549", "6585988523"),
                    new MedicoModel(5, "Kakashi",  "968215", "928645862"),
                    new MedicoModel(6, "Ichigo",  "056486", "588458852"),                    

            });

             builder.Entity<CidadeModel>()
                .HasData(new List<CidadeModel>(){
                    new CidadeModel(1, "Londrina", "PR"),
                    new CidadeModel(2, "Maringa", "PR"),
                    new CidadeModel(3, "São Paulo", "SP"),
                    new CidadeModel(4, "Rio de Janeiro", "RJ"),
                    new CidadeModel(5, "Gramado", "RS"),
                    new CidadeModel(6, "Florianopolis", "SC"),                    

            });

             builder.Entity<EspecialidadeModel>()
                .HasData(new List<EspecialidadeModel>(){
                    new EspecialidadeModel(1, "Cardiologista"),
                    new EspecialidadeModel(2, "Podologia"),
                    new EspecialidadeModel(3, "Otorrinolaringologia"),
                    new EspecialidadeModel(4, "Pediatria"),
                    new EspecialidadeModel(5, "Geral"),
                    new EspecialidadeModel(6, "Ortopedia"),

            });

            builder.Entity<UsuarioModel>()
                .HasData(new List<UsuarioModel>(){
                    new UsuarioModel(1, "Zoro", "D.Luffy", "541231849",3),
                    new UsuarioModel(2, "Goku", "SSJ.Goku", "321149366",4),
                    new UsuarioModel(3, "Yami", "Yami.Clover", "358949544",6),
                    new UsuarioModel(4, "Bakugou", "Bakugou.Hero", "6585988523",5),
                    new UsuarioModel(5, "Sasuke", "Sasuke.Amaterasu", "928645862",1),
                    new UsuarioModel(6, "Zaraki", "Zaraki.Bankai", "588458852",2),                    

            });

            builder.Entity<PrivilegioModel>()
                .HasData(new List<PrivilegioModel>(){
                    new PrivilegioModel(1, "Master"),
                    new PrivilegioModel(2, "ADM"),
                    new PrivilegioModel(3, "User"),

            });

            builder.Entity<MedicoCidade>()
            .HasKey(MC => new {MC.MedicoId,MC.CidadeId});

            builder.Entity<MedicoCidade>()
            .HasData(new List<MedicoCidade>(){
                new MedicoCidade() {MedicoId = 1, CidadeId = 1},
                new MedicoCidade() {MedicoId = 2, CidadeId = 2},
                new MedicoCidade() {MedicoId = 3, CidadeId = 3},
                new MedicoCidade() {MedicoId = 4, CidadeId = 4},
                new MedicoCidade() {MedicoId = 5, CidadeId = 5},
                new MedicoCidade() {MedicoId = 6, CidadeId = 6},
            });

             builder.Entity<MedicoEspecialidade>()
            .HasKey(MC => new {MC.MedicoId,MC.EspecialidadeId});

            builder.Entity<MedicoEspecialidade>()
            .HasData(new List<MedicoEspecialidade>(){
                new MedicoEspecialidade() {MedicoId = 1, EspecialidadeId = 1},
                new MedicoEspecialidade() {MedicoId = 2, EspecialidadeId = 2},
                new MedicoEspecialidade() {MedicoId = 3, EspecialidadeId = 3},
                new MedicoEspecialidade() {MedicoId = 4, EspecialidadeId = 4},
                new MedicoEspecialidade() {MedicoId = 5, EspecialidadeId = 5},
                new MedicoEspecialidade() {MedicoId = 6, EspecialidadeId = 6},
                
            });

        }
    }

}