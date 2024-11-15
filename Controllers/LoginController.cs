using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

public class LoginController : Controller
{
    private readonly IUserRepository _iUserRepository;

    public LoginController(IUserRepository iUserRepository)
    {
        _iUserRepository = iUserRepository;
    }
    public IActionResult Index(){
        var model =  new LoginViewModel
        {
            IsAuthenticated = HttpContext.Session.GetString("IsAuthenticated") == "true" 
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Login(LoginViewModel model){
         if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
        {
            model.ErrorMessage = "Por favor ingrese su nombre de usuario y contraseña.";
            return View("Index", model);
        }
        var usuario  = _iUserRepository.GetUser(model.Username,model.Password);
        if(usuario != null){
            HttpContext.Session.SetString("IsAuthenticated", "true");
            HttpContext.Session.SetString("Username", usuario.Username);
            HttpContext.Session.SetString("AccessLevels", usuario.AccessLevels.ToString());
            return RedirectToAction("Index","Home");
        }
        model.ErrorMessage = "Credenciales invalidas";
        model.IsAuthenticated = false;
        return View("Index",model);
    }
    public IActionResult Logout()
    {
        // Limpiar la sesión
        HttpContext.Session.Clear();

        // Redirigir a la vista de login
        return RedirectToAction("Index");
    }

}