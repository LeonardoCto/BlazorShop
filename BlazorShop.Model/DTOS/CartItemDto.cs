namespace BlazorShop.Model.DTOS
{
    public class CartItemDto
    {

        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImageUrl { get; set; }
        public decimal? Price { get; set; }
        public string? TotalPrice { get; set; }



    }
}
