
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]//Define a classe como controlador
    [Route("[controller]")]//Quando eu chamar o/filme o controlador vai ser chamado.
    public class FilmeController : ControllerBase
    {
        //lista filmes do tipo Filme
        private static List<Filme> filmes = new List<Filme>();
        //Para cadastrar o filme no sistema preciso ter uma função responsável por isso

        [HttpPost]//Parametro para mostrar que iremos criar um recurso novo no sistema.
        //[FromBody] Eu preciso indicar que esse filme ta vindo através do corpo da minha requisição
        public void AdicionaFilme([FromBody]Filme filme)
        {
            
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
    }
}
