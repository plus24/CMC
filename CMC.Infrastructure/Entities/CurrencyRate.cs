using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMC.Infrastructure.Entities
{
    public class CurrencyRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SourceCurrency { get; set; } = "AUD";
        public string TargetCurrency { get; set; } = string.Empty;
        public double Rate { get; set; } = 1;
    }
}
