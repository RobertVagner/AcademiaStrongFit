using Microsoft.EntityFrameworkCore;

namespace trabalho.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //associa os dados ao contexto
            Context context = app.ApplicationServices.GetRequiredService<Context>();
            //inserir os dados nas entidades do contexto
            context.Database.Migrate();
            //se o contexto estiver vazio
            if (!context.Personals.Any())
            {

                var registroPersonal = new Personal { Nome = "João", Especialidade = "Geral" };
                context.Personals.AddRange(registroPersonal);
                context.SaveChanges();

                var registroAluno = new Aluno { Nome = "Robert", Data_Nascimento = Convert.ToDateTime("1997/11/20"), Email = "robert@gmail.com", Instagram = "_robetvagner", Telefone = "3591529241", PersonalId = registroPersonal.PersonalId, Observacoes = "Ativo"};
                context.Alunos.AddRange(registroAluno);
                context.SaveChanges();

                var registroCategoria = new Categoria { Nome = "Peito" };
                context.Categorias.AddRange(registroCategoria);
                context.SaveChanges();

                var registroExercicio = new Exercicio { Nome = "Supino", Descricao = "15 repetições", CategoriaId = registroCategoria.CategoriaID };
                context.Exercicios.AddRange(registroExercicio);
                context.SaveChanges();

                var registroTreinoExercicio = new TreinoExercicio {ExercicioId = registroExercicio.ExercicioId };
                context.TreinoExercicios.AddRange(registroTreinoExercicio);
                context.SaveChanges();

                var registroTreino = new Treino { Data = Convert.ToDateTime("2023/03/27"), Hora = Convert.ToDateTime("21:00"), AlunoId = registroAluno.AlunoId, TreinoExercicioId = registroTreinoExercicio.TreinoExercicioId};
                context.Treinos.AddRange(registroTreino);
                context.SaveChanges();

                context.SaveChanges();
            }
        }
    }
}
