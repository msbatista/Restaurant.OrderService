namespace Restaurant.OrderService.Domain
{
    public class Address
    {
        public long Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }
}
