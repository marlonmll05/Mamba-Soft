namespace Backend.Models;

using System.ComponentModel.DataAnnotations;

public class Nomina
{
    public int Id {get; set;}
    public int EmpleadoId {get; set;}
    public Empleado? Empleado {get; set;}

    [Required]
    public decimal Monto {get; set;}

    [Required]
    public DateTime FechaPago {get; set;}

    [Required]
    public string Concepto {get; set;} = "";
}