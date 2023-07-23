using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace AspNetCoreEgitim6584.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Kategori Adı")]
        public string Name{ get; set; }
        public List<Product>? Products { get; set; }
    }
}
