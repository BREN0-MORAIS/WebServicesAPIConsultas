using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServicesAPIConsultas.Models
{
    public class Paciente
    {
        [Key]
        [Display(Name = "Código")]
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Medico")]
        public int MedicoId { get; set; }
        [Display(Name = "Hora Consulta")]
        public DateTime HoraConsulta { get; set; }
        [Display(Name = "Data Consulta")]
        public DateTime DataConsulta { get; set; }

    }
}
