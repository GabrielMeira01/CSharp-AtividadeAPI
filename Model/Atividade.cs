using System.ComponentModel.DataAnnotations;

namespace AtividadeAPI.Model
{
    public class Atividade
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Detalhe { get; set; }
        public DateTime Data { get; set; }
        public bool Finalizada { get; set; }
        [Required]
        public int Dificuldade { get; set; }
        [Required]
        public int QuantidadeHoras { get; set; }
    }
}
