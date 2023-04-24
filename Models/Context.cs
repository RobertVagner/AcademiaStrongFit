using Microsoft.EntityFrameworkCore;
namespace trabalho.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<TreinoExercicio> TreinoExercicios { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
