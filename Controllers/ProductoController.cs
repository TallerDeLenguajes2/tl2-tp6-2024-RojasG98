using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_RojasG98.Controllers;

public class ProductoController:Controller 
{
    private readonly ILogger<HomeController> _logger;
    public ProductoController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
}