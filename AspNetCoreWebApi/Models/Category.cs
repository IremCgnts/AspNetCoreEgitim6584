
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreWebApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        //public virtual List<Product>? Products { get; set; }
    }
}
