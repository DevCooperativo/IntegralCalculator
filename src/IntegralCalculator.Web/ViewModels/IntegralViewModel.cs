using System.ComponentModel.DataAnnotations;
using IntegralCalculator.DTO;

namespace IntegralCalculator.Web.ViewModels
{
    public class IntegralViewModel
    {
        [Required]
        public decimal Superior { get; set; }

        [Required]
        public decimal Inferior { get; set; }

        [Required]
        public int Passo { get; set; }

        [Required]
        public string Formula { get; set; }

        public bool RiemmanEsquerda { get; set; }
        public bool RiemmanDireita { get; set; }
        public bool RegraTrapezio { get; set; }
        public bool Regra13Simpson { get; set; }
        public bool Regra38Simpson { get; set; }

        public Dados ResRiemmanEsquerda { get; set; }
        public Dados ResPontoMedio { get; set; }
        public Dados ResRiemmanDireita { get; set; }
        public Dados ResSimpson { get; set; }
        public Dados ResTrapezio { get; set; }
        public Dados ResSimpson38 { get; set; }

    }
}
