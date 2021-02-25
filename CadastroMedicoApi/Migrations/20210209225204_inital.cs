using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroMedicoApi.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Crm = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    PrivilegioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => new { x.MedicoId, x.EspecialidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoCidade",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CidadeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicoEspecialidadeEspecialidadeId = table.Column<int>(type: "INTEGER", nullable: true),
                    MedicoEspecialidadeMedicoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoCidade", x => new { x.MedicoId, x.CidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoCidade_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoCidade_MedicoEspecialidade_MedicoEspecialidadeMedicoId_MedicoEspecialidadeEspecialidadeId",
                        columns: x => new { x.MedicoEspecialidadeMedicoId, x.MedicoEspecialidadeEspecialidadeId },
                        principalTable: "MedicoEspecialidade",
                        principalColumns: new[] { "MedicoId", "EspecialidadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicoCidade_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 1, "PR", "Londrina" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 2, "PR", "Maringa" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 3, "SP", "São Paulo" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 4, "RJ", "Rio de Janeiro" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 5, "RS", "Gramado" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 6, "SC", "Florianopolis" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Cardiologista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Podologia" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Otorrinolaringologia" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Pediatria" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Geral" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 6, "Ortopedia" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 6, "056486", "Ichigo", "588458852" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 5, "968215", "Kakashi", "928645862" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 4, "969549", "Midoriya", "6585988523" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 2, "968549", "Vegeta", "321149366" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 1, "965669", "Zoro", "541231849" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 3, "155459", "Asta", "358949544" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Master" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "ADM" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "User" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 5, "Sasuke.Amaterasu", "Sasuke", 1, "928645862" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 1, "D.Luffy", "Zoro", 3, "541231849" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 2, "SSJ.Goku", "Goku", 4, "321149366" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 3, "Yami.Clover", "Yami", 6, "358949544" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 4, "Bakugou.Hero", "Bakugou", 5, "6585988523" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 6, "Zaraki.Bankai", "Zaraki", 2, "588458852" });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId", "MedicoEspecialidadeEspecialidadeId", "MedicoEspecialidadeMedicoId" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId", "MedicoEspecialidadeEspecialidadeId", "MedicoEspecialidadeMedicoId" },
                values: new object[] { 2, 2, null, null });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId", "MedicoEspecialidadeEspecialidadeId", "MedicoEspecialidadeMedicoId" },
                values: new object[] { 3, 3, null, null });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId", "MedicoEspecialidadeEspecialidadeId", "MedicoEspecialidadeMedicoId" },
                values: new object[] { 4, 4, null, null });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId", "MedicoEspecialidadeEspecialidadeId", "MedicoEspecialidadeMedicoId" },
                values: new object[] { 5, 5, null, null });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 5, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoCidade_CidadeId",
                table: "MedicoCidade",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoCidade_MedicoEspecialidadeMedicoId_MedicoEspecialidadeEspecialidadeId",
                table: "MedicoCidade",
                columns: new[] { "MedicoEspecialidadeMedicoId", "MedicoEspecialidadeEspecialidadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_EspecialidadeId",
                table: "MedicoEspecialidade",
                column: "EspecialidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoCidade");

            migrationBuilder.DropTable(
                name: "Privilegios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
