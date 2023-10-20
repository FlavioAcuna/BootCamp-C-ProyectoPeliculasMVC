#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProyectoPeliculasMVC.Models;
public class Director
{
    [Key]
    [Required(ErrorMessage = "Este dato es requerido")]
    public int Id { get; set; }
    [Required(ErrorMessage = "Este dato es requerido")]
    [MinLength(3, ErrorMessage = "Tu nombre debe tener al menos tener 3 letras")]

    public string Nombre { get; set; }
    [Required(ErrorMessage = "Este dato es requerido")]
    [MinLength(3, ErrorMessage = "Tu Apellido debe tener al menos tener 3 letras")]
    public string Apellido { get; set; }
    [Required(ErrorMessage = "Este dato es requerido")]
    [EmailAddress(ErrorMessage = "Por favor proporciona un correo valido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Este dato es requerido")]
    public string Password { get; set; }

    public DateTime Fecha_Creacion { get; set; } = DateTime.Now;
    public DateTime Fecha_Actualizacion { get; set; } = DateTime.Now;

}