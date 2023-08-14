using System.ComponentModel.DataAnnotations;

namespace RamExpress.Models
{
    public class Category
    {
        [Key]
         public long Id { get; set; }
        public string Name { get; set; }
        public string SubCategoryName { get; set; }

    }
}
