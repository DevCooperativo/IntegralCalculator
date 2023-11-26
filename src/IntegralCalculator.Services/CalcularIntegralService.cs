using System.Data;
using System.Text.RegularExpressions;
using IntegralCalculator.Services.Helper;
using IntegralCalculator.Interfaces;
namespace IntegralCalculator.Services;
public class CalcularIntegralService : ICalcularIntegralService
{
    public decimal Funcao(string expression, decimal x)
    {
        FormuleCalculator model = new FormuleCalculator() { x = x, e = (decimal)2.71828 };
        var result = expression.CalculateFormulas(model);
        return result;
    }

    public decimal MetodoDeSimpson(decimal a, decimal b, int n, string funcao)
    {
        decimal h = (b - a) / n;
        decimal soma = 0;
        for (int i = 0; i <= n; i++)
        {
            decimal resultado = Funcao(funcao, a + i * h);
            if (i == 0 || i == n)
                soma += resultado;
            else if (i % 2 != 0)
                soma += 4 * resultado;
            else
                soma += 2 * resultado;
        }
        soma = soma * (h / 3);
        return soma;
    }

    public decimal MetodoDoPontoMedio(decimal a, decimal b, int passo, string funcao)
    {
        decimal h = (b - a) / passo;
        decimal soma = 0;

        for (int i = 1; i <= passo; i++)
        {
            decimal x = a + h * (i - (decimal)0.5);
            soma += Funcao(funcao, x);
        }

        decimal integral = h * soma;
        return integral;
    }

    public decimal MetodoDoTrapezio(decimal a, decimal b, int n, string funcao)
    {
        decimal h = (b - a) / n;
        decimal soma = Funcao(funcao, a) + Funcao(funcao, b);
        for (int i = 1; i < n; i++)
        {
            decimal x = a + i * h;
            soma += 2*Funcao(funcao, x);
        }
        return h * (soma / 2);
    }
}