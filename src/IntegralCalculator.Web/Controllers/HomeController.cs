using IntegralCalculator.Web.ViewModels;
using IntegralCalculator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegralCalculator.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICalcularIntegralService _calcularIntegralService;
    public HomeController(ICalcularIntegralService calcularIntegralService)
    {
        _calcularIntegralService = calcularIntegralService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        decimal result = _calcularIntegralService.Funcao("arccos(x)", -1);
        Console.WriteLine(result);
        return View();
    }
    [HttpPost]
    public IActionResult Calcular(IntegralViewModel integralViewModel)
    {
        
        return View();
    }
    // [HttpPost]
    // public IActionResult Index()
    // {
    //     return View();
    // }
}