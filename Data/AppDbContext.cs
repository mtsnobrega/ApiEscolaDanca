using ApiEscolaDanca.UserClass;
using Microsoft.EntityFrameworkCore;

namespace ApiEscolaDanca.Data
{
    //Esta classe representa o contexto do banco de dados para o aplicativo.
    //Ela herda de DbContext, que é uma classe do Entity Framework Core usada para interagir com o banco de dados.
    //O DbContext é responsável por gerenciar as entidades e suas interações com o banco de dados.
    //O AppDbContext é o ponto de entrada para o Entity Framework Core e é usado para configurar a conexão com o banco de dados
    public class AppDbContext : DbContext 
    {
        public DbSet<Usuarios> Usuarios_Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura a string de conexão com o banco de dados SQLite
            optionsBuilder.UseSqlServer("Server = localhost; Database = EscolaDancaDB; User Id = sa; Password = Fsi5154; Encrypt = True; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
