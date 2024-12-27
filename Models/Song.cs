using System.ComponentModel.DataAnnotations;


namespace songsApi.Models
{
    public class Song
    {
        public int Id { get; set; }




        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "Álbum é obrigatório")]
        public string Album { get; set; }


        [Required(ErrorMessage = "Artista é obrigatório")]
        public string Artista { get; set; }




        [Required(ErrorMessage = "Ano de lançamento é obrigatório")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Ano de lançamento deve ser um ano válido")]
        public string AnoLancamento { get; set; }




        [Required(ErrorMessage = "Gênero é obrigatório")]
        public string Genero { get; set; }
    }
}
