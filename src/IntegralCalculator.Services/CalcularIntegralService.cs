using System.Data;
using System.Text.RegularExpressions;
using IntegralCalculator.Services.Helper;
using IntegralCalculator.Interfaces;
using IntegralCalculator.DTO;
namespace IntegralCalculator.Services;
public class CalcularIntegralService : ICalcularIntegralService
{
    public decimal Funcao(string expression, decimal x)
    {
        FormuleCalculator model = new FormuleCalculator() { x = x, e = (decimal)2.71828 };
        var result = expression.CalculateFormulas(model);
        return result;
    }

    public Dados MetodoDeSimpson(decimal a, decimal b, int n, string funcao)
    {
        Dados dados = new Dados();
        decimal h = (b - a) / n;
        decimal soma = 0;
        for (int i = 0; i <= n; i++)
        {
            decimal resultado = Funcao(funcao, a + i * h);
            if (i == 0 || i == n)
            {
                dados.AdicionarDados(resultado / 3);
                soma += resultado;
            }
            else if (i % 2 != 0)
            {
                dados.AdicionarDados((4 * resultado) / 3);
                soma += 4 * resultado;
            }
            else
            {
                dados.AdicionarDados((2 * resultado) / 3);
                soma += 2 * resultado;
            }
        }
        soma = soma * (h / 3);
        dados.Resultado = soma;
        return dados;
    }

    public Dados MetodoDoPontoMedio(decimal a, decimal b, int passo, string funcao)
    {
        Dados dados = new Dados();
        decimal h = (b - a) / passo;
        decimal soma = 0;

        for (int i = 1; i <= passo+1; i++)
        {
            decimal x = a + h * (i - (decimal)0.5);
            soma += Funcao(funcao, x);
            dados.AdicionarDados(Funcao(funcao, x));
        }
        

        decimal integral = h * soma;
        dados.Resultado = integral;
        return dados;
    }
    public Dados RiemmanEsquerda(decimal a, decimal b, int passo, string funcao)
    {
        Dados dados = new Dados();
        decimal h = (b - a) / passo;
        decimal soma = 0;

        for (int i = 0; i < passo; i++)
        {
            decimal x = a + h * (i);
            soma += Funcao(funcao, x);
            dados.AdicionarDados(Funcao(funcao, x));
        }
        

        decimal integral = h * soma;
        dados.Resultado = integral;
        return dados;
    }
    public Dados RiemmanDireita(decimal a, decimal b, int passo, string funcao)
    {
        Dados dados = new Dados();
        decimal h = (b - a) / passo;
        decimal soma = 0;

        for (int i = 1; i <= passo+1; i++)
        {
            decimal x = a + h * (i);
            soma += Funcao(funcao, x);
            dados.AdicionarDados(Funcao(funcao, x));
        }
        

        decimal integral = h * soma;
        dados.Resultado = integral;
        return dados;
    }

    public Dados MetodoDoTrapezio(decimal a, decimal b, int n, string funcao)
    {
        Dados dados = new Dados();
        decimal h = (b - a) / n;
        decimal soma = Funcao(funcao, a) + Funcao(funcao, b);
        dados.AdicionarDados(Funcao(funcao, a));
        
        for (int i = 1; i < n; i++)
        {
            decimal x = a + i * h;
            soma += 2 * Funcao(funcao, x);
            dados.AdicionarDados(Funcao(funcao, x));
        }
        dados.AdicionarDados(Funcao(funcao, b));
        dados.Resultado = (h * (soma / 2));
        return dados;
    }

    public Dados MetodoDeSimpson38(decimal a, decimal b, int n, string funcao)
    {
        Dados dados = new Dados();

        if (n % 3 != 0)
        {
            throw new ArgumentException("O número de intervalos deve ser um múltiplo de 3.");
        }

        decimal h = (b - a) / n;
        decimal resultado = Funcao(funcao, a) + Funcao(funcao, b);
        dados.AdicionarDados(Funcao(funcao, a));
        

        for (int i = 1; i < n; i++)
        {
            decimal x = Funcao(funcao, a + (i * h));
            if(i%3==0){
                resultado += 2*Funcao(funcao, x);
                dados.AdicionarDados((2*x)*3/8);
            }
            else{
                resultado += 3*Funcao(funcao, x);
                dados.AdicionarDados((3*x)*3/8);
            }
        }
        
        dados.AdicionarDados(Funcao(funcao, b));
        resultado *= (3 * h) / 8;
        dados.Resultado = resultado;
        return dados;
    }
}