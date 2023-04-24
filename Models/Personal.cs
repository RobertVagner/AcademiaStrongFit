﻿using System.Globalization;

namespace trabalho.Models
{
    public class Personal
    {
        public int PersonalId { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public ICollection<Aluno>Alunos { get; set; }
    }
}
