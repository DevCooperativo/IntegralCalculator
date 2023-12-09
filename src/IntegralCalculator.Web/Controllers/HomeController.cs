using IntegralCalculator.Web.ViewModels;
using IntegralCalculator.Interfaces;
using IntegralCalculator.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

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
            bool RiemmanEsquerda = integralViewModel.RiemmanEsquerda;
            bool RiemmanDireita = integralViewModel.RiemmanDireita;
            bool RegraTrapezio = integralViewModel.RegraTrapezio;
            bool Regra13Simpson = integralViewModel.Regra13Simpson;
            bool Regra38Simpson = integralViewModel.Regra38Simpson;
            Dados resPontoMedio = _calcularIntegralService.MetodoDoPontoMedio(a, b, n, formula);
            Dados resRiemmanEsquerda = RiemmanEsquerda ? _calcularIntegralService.RiemmanEsquerda(a, b, n, formula):null;
            Dados resRiemmanDireita = RiemmanDireita ? _calcularIntegralService.RiemmanDireita(a, b, n, formula):null;
            Dados resSimpson = Regra13Simpson ? _calcularIntegralService.MetodoDeSimpson(a, b, n, formula):null;
            Dados resTrapezio = RegraTrapezio ?  _calcularIntegralService.MetodoDoTrapezio(a, b, n, formula):null;
            Dados resSimpson38 = Regra38Simpson ?  _calcularIntegralService.MetodoDeSimpson38(a, b, n, formula):null;
            Dados resSimpson13 = Regra13Simpson ?  _calcularIntegralService.MetodoDeSimpson(a, b, n, formula):null;



            IntegralViewModel novoIntegralViewModel = new IntegralViewModel()
            {
                Inferior = a,
                Superior = b,
                Passo = n,
                Formula = formula,
                ResPontoMedio = resPontoMedio,
                ResRiemmanEsquerda = resRiemmanEsquerda,
                ResRiemmanDireita = resRiemmanDireita,
                ResSimpson = resSimpson13,
                ResTrapezio = resTrapezio,
                ResSimpson38 = resSimpson38
            };


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