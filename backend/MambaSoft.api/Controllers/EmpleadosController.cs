using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaSoft.api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EmpleadosController: ControllerBase
{

    private readonly AppDbContext _appdbcontext;


    public EmpleadosController(AppDbContext appDbContext)
    {
        _appdbcontext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> ListarEmpleados()
    {   
        var empleado = await _appdbcontext.Empleado.ToListAsync();
        return Ok(empleado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerEmpleado(int id)
    {
        var empleado = await _appdbcontext.Empleado.FindAsync(id);

        if (empleado == null)
        {
            return NotFound();
        }

        return Ok(empleado);
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> CrearEmpleado(Empleado empleado)
    {   
        var yaExiste = await _appdbcontext.Empleado.AnyAsync(e => e.Telefono == empleado.Telefono);
        
        if (yaExiste)
        {
            return BadRequest("Ya existe un empleado con este numero de telefono");
        }

        _appdbcontext.Empleado.Add(empleado);


        await _appdbcontext.SaveChangesAsync();

        return Ok(empleado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditarEmpleado(int id, Empleado empleado)
    {
        var empleadoSelect = await _appdbcontext.Empleado.FindAsync(id);

        if (empleadoSelect == null)
        {
            return NotFound();
        }

        empleadoSelect.NombreCompleto = empleado.NombreCompleto;
        empleadoSelect.Edad = empleado.Edad;
        empleadoSelect.Cargo = empleado.Cargo;
        empleadoSelect.FechaIngreso = empleado.FechaIngreso;
        empleadoSelect.Telefono = empleado.Telefono;
        empleadoSelect.SalarioBase = empleado.SalarioBase;

        await _appdbcontext.SaveChangesAsync();

        return Ok(empleado);


    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarEmpleado(int id)
    {
        var empleado = await _appdbcontext.Empleado.FindAsync(id);

        if (empleado == null)
        {
            return NotFound();
        }

        _appdbcontext.Empleado.Remove(empleado);

        await _appdbcontext.SaveChangesAsync();
                
        return NoContent();
    }



}