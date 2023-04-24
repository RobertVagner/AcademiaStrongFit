namespace trabalho.Models
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }
        public int CategoriaId { get; set; }
        //public int TreinoExercicioId { get;set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        //public TreinoExercicio TreinoExercicio { get; set; }
        public Categoria Categoria { get; set; }
    }
}
