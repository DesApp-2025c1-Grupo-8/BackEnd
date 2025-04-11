using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

public class Estado_His
{

    public int Id { get; set; } // Primary Key
    public int EstadoId { get; set; } // Foreign Key to Estados
    [ForeignKey("EstadoId")]
    public Estado Estado { get; set; } // Navigation property to Estados
    [Required]
    public string Nombre { get; set; } // Nombre del estado
    [Required]
    public string Descripcion { get; set; } // Descripción del estado
    [Required]
    public DateTime FechaCreacion { get; set; } // Fecha de creación del registro
    [Required]
    public DateTime FechaModificacion { get; set; } // Fecha de modificación del registro
    [Required]
    public string Action { get; set; } // Acción realizada (creado, modificado, eliminado)
}
