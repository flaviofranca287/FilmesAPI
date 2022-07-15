using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext //Mostro que ele será o conector entre o banco de dados com a API
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt) //Recebo as opções do filme context e o construtor da classe já recebe e faz tudo pra gente
        {


        }
        // é o nosso conjunto de dados do banco que vamos conseguir fazzer de maneira encapsulada o acesso aos dados do banco.
        public DbSet<Filme> Filmes { get; set; }
    }

}
