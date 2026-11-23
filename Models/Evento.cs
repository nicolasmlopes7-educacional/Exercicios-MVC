using System.ComponentModel.DataAnnotations;
namespace ExerciciosMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }


        [StringLength(80, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 80 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; } = string.Empty;


        [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres.")]
        [Required(ErrorMessage = "A descrição é obrigatoria")]
        public string Descricao { get; set; } = string.Empty;


        [StringLength(100, MinimumLength = 3, ErrorMessage = "Local deve ter entre 3 e 100 caracteres.")]
        [Required(ErrorMessage = "O local é obrigatorio")]
        public string Local { get; set; } = string.Empty;


        public DateTime DataEvento { get; set; }



        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Quantidades de vagas deve ter entre 1 e 1000 caracteres.")]
        public int QuantidadeVagas { get; set; }
        

        public decimal ValorIngresso { get; set; }


    }
}