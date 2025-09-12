using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Model.DTOS
{
    public class CartItemAddDto
    {
        [Required]
        public int CartId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
