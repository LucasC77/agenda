using System.Data;
using System.Security.Cryptography.X509Certificates;
using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore;
using Agenda.ViewModels;

namespace Agenda.Controllers
{
    [ApiController]
        public class AgendaController: ControllerBase
    {
        //todos os métodos(post, get, etc...)

        [HttpGet("/")]

        public async Task<IActionResult> GetAsync([FromServices]AppDbContext context)
        {
            return Ok(await context.Agendas.ToListAsync());
        }

        [HttpPost("/")]

        public async Task<IActionResult> PostAsync([FromBody] CreateAgendaViewModel model,
            [FromServices]AppDbContext context)
        {
            var agenda = new AgendaModel 
            {
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Telefone = model.Telefone
            };

            await context.Agendas.AddAsync(agenda);
            await context.SaveChangesAsync();

            return Created($"/{agenda.Id}", agenda);

        }

        [HttpGet("/{id:int}")]

            public async Task<IActionResult> GetByIdAsync(
                [FromRoute] int id,
                [FromServices]AppDbContext context

            )
            {
                var agenda = await context.Agendas.FindAsync(id);
                if(agenda == null) return NotFound();
                
                return Ok(agenda);
            }



        [HttpDelete("/{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id,
            [FromServices]AppDbContext context
        )
        {
            var agenda = await context.Agendas.FindAsync(id);
            if(agenda == null) return NotFound();
            context.Agendas.Remove(agenda);
            await context.SaveChangesAsync();

            return Ok(agenda);

        }
    

        [HttpPut("/{id:int}")]

        public async Task<IActionResult> PutAsync([FromRoute] int id,
        [FromBody] AgendaModel umaAgenda,
        [FromServices] AppDbContext context
        )
    {
        var agenda = await context.Agendas.FindAsync(id);

        if (agenda == null) return NotFound();

        agenda.Nome = umaAgenda.Nome;
        agenda.Telefone = umaAgenda.Telefone;
        agenda.DataNascimento = umaAgenda.DataNascimento;

        await context.SaveChangesAsync();
        return Accepted();
    }

    }

}