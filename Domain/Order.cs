namespace Domain
{
    public class Order
    {
        public decimal TotalAmount { get; set; }
        public User Customer { get; set; }
        public string PromoCode { get; set; } = string.Empty;
    }
}
