using System.ComponentModel.DataAnnotations.Schema;

namespace RamExpress.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
  
        public string Country { get; set; }
    }
}
