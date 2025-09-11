using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public Cart? Cart { get; set; } // 1:1 opcional, o usuario pode ou nao ter um carrinho


    }
}
