using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_RojasG98.Controllers;

class PresupuestoController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PresupuestoController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
}