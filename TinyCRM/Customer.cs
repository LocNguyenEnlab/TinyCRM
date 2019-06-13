namespace TinyCRM
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailOffice { get; set; }
        public int PhoneOffice { get; set; }
        public string EmailHome { get; set; }
        public int PhoneHome { get; set; }

        //return true if this.customer = customer, false if not equal
        public bool Compare(Customer customer)
        {
            if (customer.Name != this.Name)
                return false;
            if (customer.EmailHome != this.EmailHome)
                return false;
            if (customer.PhoneHome != this.PhoneHome)
                return false;
            if (customer.EmailOffice != this.EmailOffice)
                return false;
            if (customer.PhoneHome != this.PhoneHome)
                return false;
            return true;
        }
    }
}