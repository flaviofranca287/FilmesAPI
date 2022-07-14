
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

        private static int id = 1;
        [HttpPost]//Parametro para mostrar que iremos criar um recurso novo no sistema.
        //[FromBody] Eu preciso indicar que esse filme ta vindo através do corpo da minha requisição
        public void AdicionaFilme([FromBody]Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
        }
        [HttpGet]
        //Poderia ser List<Filme> mas se em algum momento a gente não estiver retornando uma lista de filme, mas sim uma classe que implemente essa interface, com o IEnumerable, não vai quebrar.
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return filmes;
        }
    }
}
