using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades;

public class Estado
{
    public int Id { get; set; } // Primary Key
    [Required]
    public string Nombre { get; set; } // Nombre del estado
    [Required]
    public string Descripcion { get; set; } // Descripción del estado
    [Required]
    public DateTime FechaCreacion { get; set; } // Fecha de creación del registro
    [Required]
    public DateTime FechaModificacion { get; set; } // Fecha de modificación del registro
    [Required]
    public bool State { get; set; } // Estado del registro (activo/inactivo)
}
