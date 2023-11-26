namespace IntegralCalculator.DTO;

public class Dados
{
    private List<decimal> _individual;

    public Dados()
    {
        _individual = new List<decimal>();
    }
    public decimal Resultado { get; set; }
    public List<decimal> Individual { get=>_individual; set=>_individual=value; }


    public void AdicionarDados(decimal valor){

        _individual.Add(valor);
    }
}