using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage="O campo Título é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="O campo Diretor é obrigatório.")]
        public string Diretor { get; set; }
        [StringLength(20,ErrorMessage ="O campo Genero não pode passar de 20 caracteres.")]
        public string Genero { get; set; }
        [Range(1,600,ErrorMessage ="A duração permitida é de 1 a 600.")]
        public int Duracao { get; set; }

    }
}
