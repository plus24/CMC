using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMC.Infrastructure.Entities
{
    public class ShippingCost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Threshold { get; set; } = double.MaxValue;
        public double Price { get; set; } = 0;
    }
}
