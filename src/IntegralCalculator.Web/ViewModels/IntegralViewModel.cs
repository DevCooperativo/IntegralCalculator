using System.ComponentModel.DataAnnotations;

namespace IntegralCalculator.Web.ViewModels;

public class IntegralViewModel
{
    [Required]
    public int Superior;
    [Required]
    public int Inferior;
    [Required]
    public double Passo;
    [Required]
    public string Formula;
    public double Resultado;
}