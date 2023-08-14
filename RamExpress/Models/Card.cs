using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamExpress.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
