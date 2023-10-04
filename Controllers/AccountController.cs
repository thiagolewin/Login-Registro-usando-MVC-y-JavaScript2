using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;
using System;
using System.Text;
using System.Security.Cryptography;
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

    return View("IngresarNombreOlvidar");
    }
    public IActionResult MailOlvide(string mail) {
        User usuario = BD.Email(mail);
        if(usuario != null) {
            ViewBag.Pregunta = usuario.PreguntaPersonal;
            ViewBag.Email = mail;
            return View("OlvideContraseña");
        } else {
            ViewBag.Texto = "Ese mail no existe";
            return View("IngresarNombreOlvidar");
        }
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
            using (MD5 md5Hash = MD5.Create())
            {
                contraseña = Seguridad.GetMd5Hash(md5Hash, contraseña);
            }
        @ViewBag.Usuario = BD.Login(usuario,contraseña);
        if(@ViewBag.Usuario != null) {
            return View("PostLogin");
        } else {
            ViewBag.Incorrecto = "Usuario o contraseña incorrectos!";
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
    public IActionResult IngresarRegister(string usuario, string contraseña, string telefono, string email, string nombre, string personal, string preguntaPersonal) {
        if (usuario == null || contraseña == null || telefono == null || email == null || nombre == null || personal == null || preguntaPersonal == null) {
            ViewBag.Incorrecto = "Datos vacios!";
             return View("Register");
        }
        if (BD.Username(usuario) != null) {
              ViewBag.Incorrecto = "Nombre de usuario ya en uso";
             return View("Register");
        }
         if (BD.Email(email) != null) {
              ViewBag.Incorrecto = "Email ya en uso";
             return View("Register");
        }
        using (MD5 md5Hash = MD5.Create())
            {
                contraseña = Seguridad.GetMd5Hash(md5Hash, contraseña);
            }
        User user = new User(usuario,contraseña,telefono,email,nombre,personal,preguntaPersonal);
        BD.Register(user);
        @ViewBag.Usuario = user;
       return View("PostLogin");
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