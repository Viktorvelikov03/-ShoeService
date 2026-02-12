namespace ShoeService.Models.Requests
{
    public class BuyShoesRequest
    {
        public string CustomerId { get; set; } = string.Empty;
        public string ShoeId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
