using IntegralCalculator.Web.ViewModels;
using IntegralCalculator.Interfaces;
using IntegralCalculator.DTO;
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
        return View();
    }
    [HttpPost]
    public IActionResult Index(IntegralViewModel integralViewModel)
    {
        try
        {
            decimal a = integralViewModel.Inferior;
            decimal b = integralViewModel.Superior;
            int n = integralViewModel.Passo;
            string formula = integralViewModel.Formula;
            Dados resPontoMedio = _calcularIntegralService.MetodoDoPontoMedio(a, b, n, formula);
            Dados resSimpson = _calcularIntegralService.MetodoDeSimpson(a, b, n, formula);
            Dados resTrapezio = _calcularIntegralService.MetodoDoTrapezio(a, b, n, formula);
            Dados resSimpson38 = _calcularIntegralService.MetodoDeSimpson38(a, b, n, formula);

            IntegralViewModel novoIntegralViewModel = new IntegralViewModel() { Inferior = a, Superior = b, Passo = n, Formula = formula, ResPontoMedio = resPontoMedio, ResSimpson = resSimpson, ResTrapezio = resTrapezio, ResSimpson38 = resSimpson38 };

            return View(novoIntegralViewModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    // [HttpPost]
    // public IActionResult Index()
    // {
    //     return View();
    // }
}