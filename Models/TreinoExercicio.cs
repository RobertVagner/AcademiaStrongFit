namespace trabalho.Models
{
    public class TreinoExercicio
    {
        public int TreinoExercicioId { get; set; }
        public int ExercicioId { get; set; }
        public ICollection<Treino>Treinos { get; set; }
        public ICollection<Exercicio> Exercicios { get; set;}
        public Exercicio Exercicio { get; set; }
    }
}
