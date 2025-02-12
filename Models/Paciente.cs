//Copyright (c) 2025 Héricles França da Silva. Todos os direitos reservados. 

using System.Collections.Generic;

namespace relatorio_medico.Models
{
    class Paciente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Diagnostico { get; set; }
        public string Prescricao { get; set; }
        public List<Exame> Exames { get; set; }
    }
}
