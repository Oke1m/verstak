namespace Tspu.Contract
{
    public class AddProductRequestContract
    {
       
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageURL { get; set; }
    }
}

