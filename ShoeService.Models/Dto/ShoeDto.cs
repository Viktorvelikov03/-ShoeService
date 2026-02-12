namespace ShoeService.Models.Dto
{
    public class ShoeDto
    {
        public string Id { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
