using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace trabalho.Models
{
    public class Treino
    {
        public int TreinoId { get; set; }
        public int TreinoExercicioId { get; set; }
        public int AlunoId { get; set; }

        [Display(Name = "Data do treino")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Display(Name = "Hora do treino")]
        public DateTime Hora { get; set; }
        public Aluno Aluno { get; set;}
        public TreinoExercicio TreinoExercicio { get; set; }
    }
}
