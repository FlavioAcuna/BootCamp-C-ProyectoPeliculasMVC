using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoPeliculasMVC.Models;

namespace ProyectoPeliculasMVC.Controllers;

public class HomeController : Controller
{
    public static List<Director> ListaDirectorees = new List<Director>();
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        Director NuevoDirector = new Director()
        {
            Id = 123,
            Nombre = "Alex",
            Apellido = "Miller"
        };
        return View("index", NuevoDirector);
    }
    [HttpGet]
    [Route("/privacy")]
    public IActionResult Privacy()
    {
        return View("privacy");
    }
    [HttpGet]
    [Route("/directores")]
    public IActionResult Directores()
    {/* Select * from directores */
        List<Director> ListaDirectoresLINQ = _context.Directores.ToList();
        return View("Directores", ListaDirectoresLINQ);
    }

    [HttpGet]
    [Route("formulario/director")]
    public IActionResult FormularioDirector()
    {

        return View("FormularioDirector");
    }
    [HttpPost]
    [Route("nuevo/director")]
    public IActionResult AgregarDirector(Director NuevoDirector)
    {
        if (ModelState.IsValid)
        {
            ListaDirectorees.Add(NuevoDirector);
            return RedirectToAction("Directores");
        }
        return View("FormularioDirector");
    }
    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View("login");
    }
    [HttpPost]
    [Route("/procesa/login")]
    public IActionResult ProcesaLogin(Login login)
    {
        if (ModelState.IsValid)
        {
            foreach (Director director in ListaDirectorees)
            {
                if (director.Email == login.Email && director.Password == login.Password)
                {
                    HttpContext.Session.SetString("Nombre", director.Nombre);
                    HttpContext.Session.SetString("Apellido", director.Apellido);
                    HttpContext.Session.SetString("Email", director.Email);
                    return RedirectToAction("index");
                }
                return View("login");
            }
        }
        return View("login");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
