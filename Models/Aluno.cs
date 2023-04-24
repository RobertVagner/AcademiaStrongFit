using System.ComponentModel.DataAnnotations;

namespace trabalho.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_Nascimento { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Digite um endereço válido com @")]
        public string Email { get; set; }
        public string Instagram { get; set; }

        [Display(Name = "Telefone")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$", ErrorMessage = "Digite o telefone no formato (xx) 9xxxx-xxxx")]
        public string Telefone { get; set; }
        [Display(Name = "Personal")]
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
        public string Observacoes { get; set; }
        public ICollection<Treino>Treinos { get; set; }
    }
}
