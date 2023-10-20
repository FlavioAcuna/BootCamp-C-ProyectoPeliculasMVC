//
#pragma warning disable CS8618
// Podemos desactivar nuestras advertencias de forma segura porque sabemos que el framework asignará valores no nulos
// cuando construye esta clase para nosotros.
using Microsoft.EntityFrameworkCore;
namespace ProyectoPeliculasMVC.Models;
/*
la clase MyContext representa una sesión con nuestra base de datos MySQL, permitiéndonos consultar o guardar datos
DbContext es una clase que proviene de EntityFramework, queremos heredar sus características
*/
public class MyContext : DbContext
{
    public DbSet<Director> Directores { get; set; }
    
    
    //Esta línea siempre estará aquí. Es lo que construye nuestro contexto en la inicialización
    public MyContext(DbContextOptions options) : base(options) { }
    /*
    Tenemos que crear un nuevo DbSet<Model> para cada modelo en nuestro proyecto que está haciendo una tabla.
    El nombre de nuestra tabla en nuestra base de datos se basará en el nombre que proporcionamos aquí
    Aquí es donde proporcionamos una versión plural de nuestro modelo para ajustarse a los estándares de nomenclatura de tablas
    */

}