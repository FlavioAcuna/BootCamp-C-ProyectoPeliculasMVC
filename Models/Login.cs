#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProyectoPeliculasMVC.Models;
public class Login
{
    [Required(ErrorMessage = "Este dato es requerido")]
    [EmailAddress(ErrorMessage = "Por favor proporciona un correo valido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Este dato es requerido")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}