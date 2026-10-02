using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaSoft.api.Controllers;


[ApiController]
[Route("/api/[Controller]")]
public class NominaController : ControllerBase
{   
    private readonly AppDbContext _appdbcontext;

    public NominaController(AppDbContext appDbContext)
    {
        _appdbcontext = appDbContext;
    }
    

    [HttpGet]
    public async Task<IActionResult> ConsultarNomina()
    {
        var nomina = await _appdbcontext.Nomina.ToListAsync();

        return Ok(nomina);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsultarPorId(int id)
    {
        var nomina = await _appdbcontext.Nomina.FindAsync(id);

        return Ok(nomina);
    }

    [HttpPost]
    public async Task<IActionResult> CrearNomina(Nomina nomina)
    {   
        var empleadoExiste = await _appdbcontext.Empleado.AnyAsync(e => e.Id == nomina.EmpleadoId);

        if (!empleadoExiste)
        {
            return NotFound("No existe el empleado con ID: " +  nomina.EmpleadoId);
        }

        var nominaCreada = await _appdbcontext.Nomina.AddAsync(nomina);
        
        await _appdbcontext.SaveChangesAsync();
        return Ok(nominaCreada);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Nomina>> EditarNomina(Nomina nomina, int id)
    {
        var nominaSelect = await _appdbcontext.Nomina.FindAsync(id);

        if (nominaSelect == null)
        {
            return NotFound();
        }

        nominaSelect.Concepto = nomina.Concepto;
        nominaSelect.EmpleadoId = nomina.EmpleadoId;
        nominaSelect.FechaPago = nomina.FechaPago;
        nominaSelect.Monto = nomina.Monto;

        await _appdbcontext.SaveChangesAsync();

        return nominaSelect;

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarNomina(int id)
    {

        var nominaSelect = await _appdbcontext.Nomina.FindAsync(id);

        if (nominaSelect == null)
        {
            return NotFound();
        }


        _appdbcontext.Remove(nominaSelect);
        await _appdbcontext.SaveChangesAsync();

        return Ok();
    }

}