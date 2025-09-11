using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Api.Entities
{
    public class Product
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ImageUrl { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }  
        public int Quantity { get; set; }

        public int CategoryId { get; set; } //FK explicita 1:N um produto só pode ter uma categoria mas uma categoria pode ter vários produtos
                                            //Fica do lado muitos  a FK
        public Category Category { get; set; } ////navegação de refencia lado um (produto só pode ter uma categoria) p.Include(p=>p.Category)

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>(); ///Usamos IColletion pois depois podemos alterar o tipo desta coleção fica flexivel posso 
                                                                                 //usar as classes metodos que a interface implementa
        
    }
}
