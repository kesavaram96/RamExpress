using System.ComponentModel.DataAnnotations.Schema;

namespace RamExpress.Models
{
    public class ReviewRatings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public float Rating { get; set; }
        public string Review { get; set; }

    }
}
