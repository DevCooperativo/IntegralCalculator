using System.ComponentModel.DataAnnotations;

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

        public decimal ResPontoMedio { get; set; }
        public decimal ResSimpson { get; set; }
        public decimal ResTrapezio { get; set; }
    }
}
