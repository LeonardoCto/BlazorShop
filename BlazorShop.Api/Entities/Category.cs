using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class Category
    {
        public int Id { get; set; } //Definimos este id para o ORM entender e definir essa como chave primária

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string IconCss { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new Collection<Product>(); //Navegaçao de coleções (categoriaBlusa.Products) lado muitos (categoria pode ter varios produtos)
    }
}
