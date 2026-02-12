namespace ShoeService.Models.Responses
{
    public class BuyShoesResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
