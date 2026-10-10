using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAtividade.API.Data;
using ProAtividade.API.Models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly DataContext _context;
        public AtividadeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _context.Atividades;
        }

        [HttpGet("{id}")]
        public Atividade get(int id)
        {
            return _context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
           if (atividade.Id != id)
                throw new Exception("Voce esta tentando atualizar a atividade errada");

            _context.Atividades.Update(atividade);
            if (_context.SaveChanges() > 0)
                return atividade;
            else
                return new Atividade();
        }

        [HttpPost]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
                if (_context.SaveChanges() > 0)
                    return _context.Atividades;
                else
                    throw new Exception("Não foi possível salvar a atividade");   
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var atividade = _context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
            if (atividade == null) throw new Exception("Atividade não encontrada");

            _context.Remove(atividade);
            
            return _context.SaveChanges() > 0;
        }
    }
}