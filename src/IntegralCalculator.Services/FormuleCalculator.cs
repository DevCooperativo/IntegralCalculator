using IntegralCalculator.Interfaces;

namespace IntegralCalculator.Services;
public class FormuleCalculator : IFormuleCalculator
{
    public decimal x { get; set; }
    public decimal e { get; set; }
    public decimal pi { get; set; }
}