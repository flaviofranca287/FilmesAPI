using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile//Classe do automapper
    {
        public FilmeProfile()//Construtor
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
