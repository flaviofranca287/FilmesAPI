
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
        public IActionResult AdicionaFilme([FromBody]Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            //Retorna o caminho para o filme que foi criado
            //CreatedAtAction = Qual é a ação que precisamos executar para recuperar esse recurso, que é a recuperafilmesporid, o valor que vai estar na rota(que é o ID) e por ultimo o objeto que queremos que é o filme.
            return CreatedAtAction(nameof(RecuperaFilmesPorId),new {id = filme.Id},filme);
        
        }
        [HttpGet]
        //Poderia ser List<Filme> mas se em algum momento a gente não estiver retornando uma lista de filme, mas sim uma classe que implemente essa interface, com o IEnumerable, não vai quebrar.
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        }
        [HttpGet("{id}")]
        //public Filme RecuperaFilmesPorId(int id)

        public IActionResult RecuperaFilmesPorId(int id)
        {
            //foreach(Filme filme in filmes){
            //    if(filme.Id == id)
            //    {
            //        return filme;
            //    }
            //}
            //return null;
            //return filmes.FirstOrDefault(filme => filme.Id == id);
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
