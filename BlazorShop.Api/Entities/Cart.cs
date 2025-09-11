namespace BlazorShop.Api.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Relação 1:1 com user a FK fica no lado dependente um carrinho deve ter um usuário
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
