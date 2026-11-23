namespace ExerciciosMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public DateTime DataEvento { get; set; }
        public int QuantidadeVagas { get; set; }
        public decimal ValorIngresso { get; set; }
    }
}