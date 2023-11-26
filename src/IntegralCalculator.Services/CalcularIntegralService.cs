using System.Data;
using System.Text.RegularExpressions;
using IntegralCalculator.Services.Helper;
using IntegralCalculator.Interfaces;
namespace IntegralCalculator.Services;
public class CalcularIntegralService : ICalcularIntegralService
{
    public decimal Funcao(string expression, decimal x)
    {
        // string expressao = expression.Replace("x", x.ToString());
        // expressao = expressao.Replace("sqrt", "Math.Sqrt");
        // DataTable table = new DataTable();
        // // Avalia a expressão usando a função Compute
        // object result = table.Compute(expressao, "");


        // // Converte o resultado para um número de ponto flutuante
        // double resultado = Convert.ToDouble(result);

        // return resultado;
        // String source = "(x*x)/4";

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
}