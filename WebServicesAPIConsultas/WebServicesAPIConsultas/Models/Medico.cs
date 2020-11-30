using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServicesAPIConsultas.Models
{
    public class Medico
    {
            [Key]
            [Display(Name = "Código")]
            public int MedicoId { get; set; }

            public string Nome { get; set; }
            public string Especialidade { get; set; }
    }
}
