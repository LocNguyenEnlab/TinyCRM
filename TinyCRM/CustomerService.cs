using System;
using System.Collections.Generic;

namespace TinyCRM
{
    public class CustomerService
    {
        List<Customer> FakeData = new List<Customer>();
        public CustomerService()
        {
            Customer cus = new Customer
            {
                Id = 1,
                Name = "LOC",
                EmailHome = "loc@gmail.com",
                PhoneHome = 0393384646,
                EmailOffice = "loc.nguyen@enlabsoftware.com",
                PhoneOffice = 456
            };
            FakeData.Add(cus);
        }

        public void Save(Customer customer)
        {
            if (FakeData.Count == 0)
            {
                customer.Id = 1;
            } else
            {
                customer.Id = FakeData[FakeData.Count - 1].Id + 1;
            }
            FakeData.Add(customer);
        }

        internal Customer GetCustomerById(int idCustomer)
        {
            foreach(var item in FakeData)
            {
                if (item.Id == idCustomer)
                {
                    return item;
                }
            }
            return null;
        }

        internal bool IsValidCustomerByCustomer(Customer newCustomer)
        {
            foreach(var item in FakeData)
            {
                if (item.Compare(newCustomer))
                    return false;
            }
            return true;
        }

        internal bool IsValidCustomerById(int idCustomer)
        {
            foreach (var item in FakeData)
            {
                if (item.Id == idCustomer)
                {
                    return true;
                }
            }
            return false;
        }

        internal void DeleteById(int idCustomer)
        {
            foreach(var item in FakeData)
            {
                if (item.Id == idCustomer)
                {
                    FakeData.Remove(item);
                    break;
                }
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return FakeData;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}