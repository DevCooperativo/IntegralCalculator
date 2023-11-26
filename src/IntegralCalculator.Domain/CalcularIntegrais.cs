namespace IntegralCalculator.Domain.CalcularIntegrais;

public class CalcularIntegrais
{
    public int superior;
    public int inferior;
    public double passo;
    public Func<double, double> funcao = f => (f * f);

    // public CalcularIntegrais(int superior=0, int inferior=0, double passo=0)
    // {
    //     this.superior = superior;
    //     this.inferior = inferior;
    //     this.passo = passo;
    // }

    public void DefinirFuncao(){
        this.funcao = x => (x * x);//Declarar Funcao aqui
    }

    public double Trapezio()
    {
        double resultado = 0;
        for (double i = this.inferior; i <= this.superior; i += this.passo)
        {
            resultado += this.funcao(i);
        }
        return resultado;
    }
    public double PontoMedio()
    {
        double h = (this.superior - this.inferior) / this.passo;
        double soma = 0;

        for (int i = 1; i <= this.passo; i++)
        {
            double x = this.inferior + h * (i - 0.5);
            soma += this.funcao(x);
        }

        double integral = h * soma;
        return integral;
    }
}