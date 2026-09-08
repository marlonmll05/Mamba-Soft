namespace Backend.Models;

public class Empleado
{  
    public int Id {get; set;}
    public string NombreCompleto {get; set;} = "";
    public int Edad {get; set;}
    public string Cargo {get; set;} = "";
    public DateTime FechaIngreso {get; set;}
    public string Telefono {get; set;} = "";
    public decimal SalarioBase {get; set;}
}