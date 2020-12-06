using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServicesAPIConsultas.Data;
using WebServicesAPIConsultas.Models;

namespace WebServicesAPIConsultas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public  PacienteController(AppDbContext contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Pacientes);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var paciente =_context.Pacientes.FirstOrDefault(a => a.PessoaId == id);
            if (paciente == null) return BadRequest("Paciente Não encontrado");
            return Ok(paciente);
        }

        [HttpGet("byname")]

        public IActionResult GetByName(string nome, string sobrenome)
        {
            var paciente = _context.Pacientes.FirstOrDefault(a => a.Nome.Contains(nome)  && a.Sobrenome.Contains(sobrenome));
            if (paciente == null) return BadRequest("Nome de Pacente Não encontrado");
            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            _context.Add(paciente);
            _context.SaveChanges();

            return Ok(paciente);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id , Paciente paciente)
        {
            var pace = _context.Pacientes.AsNoTracking().FirstOrDefault(a => a.PessoaId == id);
            if (pace == null) return BadRequest("Não foi possivel atualizar o Paciente");
            _context.Update(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.AsNoTracking().FirstOrDefault(a => a.PessoaId == id);

            if (paciente == null) return BadRequest("Não foi possivel remover o Paciente");

            _context.Remove(paciente);
            _context.SaveChanges();

            return Ok(paciente);
            
        }
    }
}
