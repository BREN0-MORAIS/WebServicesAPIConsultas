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
    public class MedicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicoController(AppDbContext contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Medicos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _context.Medicos.FirstOrDefault(a => a.MedicoId == id);
            if (paciente == null) return BadRequest("Paciente Não encontrado");
            return Ok(paciente);
        }

        [HttpGet("byname")]

        public IActionResult GetByName(string nome)
        {
            var paciente = _context.Medicos.FirstOrDefault(a => a.Nome.Contains(nome));
            if (paciente == null) return BadRequest("Nome de Pacente Não encontrado");
            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            _context.Add(medico);
            _context.SaveChanges();

            return Ok(medico);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medico)
        {
            var pace = _context.Medicos.AsNoTracking().FirstOrDefault(a => a.MedicoId == id);
            if (pace == null) return BadRequest("Não foi possivel atualizar o Paciente");
            _context.Update(medico);
            _context.SaveChanges();
            return Ok(medico);
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            var medico = _context.Medicos.AsNoTracking().FirstOrDefault(a => a.MedicoId == id);

            if (medico == null) return BadRequest("Não foi possivel remover o Paciente");

            _context.Remove(medico);
            _context.SaveChanges();

            return Ok(medico);

        }
    }
}
