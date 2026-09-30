namespace Backend.Models;
using System.ComponentModel.DataAnnotations;
public class Empleado
    {  
    public int Id {get; set;}

    [Required]
    [MaxLength(100, ErrorMessage = "El Nombre no puede superar los 100 caracteres")]
    public string NombreCompleto {get; set;} = "";

    [Range(16, 70, ErrorMessage = "La edad debe ser entre 16 y 70 años")]
    public int Edad {get; set;}

    [Required]
    public string Cargo {get; set;} = "";

    public DateTime FechaIngreso {get; set;}

    [Required]
    public string Telefono {get; set;} = "";

    [Range(0.01, 999999999, ErrorMessage = "El salario debe ser mayor a 0")]
    public decimal SalarioBase {get; set;}
}