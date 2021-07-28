using System.Collections.Generic;

namespace Restaurant.OrderService.Domain
{
    public class Client
    {
        public long Id { get; set; }
        public long Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Account Account { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
    }
}
