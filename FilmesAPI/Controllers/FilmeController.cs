﻿using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        //Para começar inserir informações/ler informações do banco vamos utilizar o nosso contexto(FilmeContext) pois temos lá um conjunto de dados nos referindo aos nossos filmes.
        private FilmeContext _context;// é um campo inicializada com _context

        public FilmeController(FilmeContext context)
        {
            //inicializamos o carinha de cima.
            _context = context;
        }
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            //Adicionar um objeto mapeado no banco através do DbContext e salvar essa operação
            _context.Filmes.Add(filme);
            _context.SaveChanges();//Sem isso ele não salva o estado.
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
