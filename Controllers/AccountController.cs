using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Olvide() {

    return View("OlvideContraseña");
    }
    public IActionResult OlvideComprobacion(string mail, string personal) {
        User usuario = BD.Olvide(mail,personal);
        if (usuario != null) {
            ViewBag.Contraseña = usuario.Contraseña;
            return View("OlvideContraseña");
        } else {
            ViewBag.Contraseña = "Esa no es tu clave de respuesta personal";
            return View("OlvideContraseña");
        }
    }
    public IActionResult Login() {

        return View("Login");
    }
    public IActionResult ValidarLogin(string usuario, string contraseña) {
        @ViewBag.Usuario = BD.Login(usuario,contraseña);
        if(@ViewBag.Usuario != null) {
            return View("PostLogin");
        } else {
            return View("Login");
        }
    }
    public IActionResult Register() {
         string[] Preguntas = new string[6];
        Preguntas[0] = "¿Cuál es tu comida favorita?";
        Preguntas[1] = "¿Qué lugar del mundo te gustaría visitar más?";
        Preguntas[2] = "¿Tienes alguna afición o pasatiempo que te apasione?";
        Preguntas[3] = "¿Cuál es tu libro o película favorita y por qué?";
        Preguntas[4] = "¿Qué es lo que más te motiva en la vida?";
        Preguntas[5] = "Si pudieras tener una conversación con cualquier persona, viva o fallecida, ¿quién sería y qué le dirías?";
        Random random = new Random();
        int numeroRandom = random.Next(0, 6);
        @ViewBag.Pregunta = Preguntas[numeroRandom];
        return View("Register");
    }
    public IActionResult IngresarRegister(string usuario, string contraseña, string telefono, string email, string nombre, string personal) {
        User user = new User(usuario,contraseña,telefono,email,nombre,personal);
        BD.Register(user);
        @ViewBag.Usuario = user;
        return View("Register");
    }
    public IActionResult OlvideContraseña() {
        return View("OlvideContraseña");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}