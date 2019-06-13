using System;
using System.Collections.Generic;

namespace TinyCRM
{
    public class UserInterface
    {
        public int _enteringNumber;
        public Customer _customer;
        public CustomerService _service;
        public UserInterface()
        {            
        }
                
        public void ShowMainMenu()
        {
            Console.WriteLine("====>MENU<====");
            Console.WriteLine("1. Add new customer");
            Console.WriteLine("2. Edit a customer");
            Console.WriteLine("3. Delete a customer");
            Console.WriteLine("4. Show customers");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Input your option: ");
            
            try
            {
                _enteringNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception )
            {
                
            }
        }

        internal void ShowEnteringIdToEdit()
        {
            Console.Write("Input id customer to edit: ");
            _enteringNumber = Convert.ToInt32(Console.ReadLine());

        }

        public int GetEnteringInputNumber()
        {
            return _enteringNumber;
        }

        public void ShowEnteringCustomer()
        {
            _service = new CustomerService();
            _customer = new Customer();
            Console.Write("Name: ");
            _customer.Name = Console.ReadLine();
            
            while(true)
            {
                Console.Write("Email Office: ");
                _customer.EmailOffice = Console.ReadLine();
                if (_service.IsValidEmail(_customer.EmailOffice))
                {
                    break;
                } else
                {
                    Console.WriteLine("Invalid email address, please input again");
                }
            }
            while(true)
            {
                try
                {
                    Console.Write("Phone Office: ");
                    _customer.PhoneOffice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid phone number, please input again");
                }
            }
            while (true)
            {
                Console.Write("Email Home: ");
                _customer.EmailHome = Console.ReadLine();
                if (_service.IsValidEmail(_customer.EmailHome))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email address, please input again");
                }
            }
            
            while(true)
            {
                try
                {
                    Console.Write("Phone Home: ");
                    _customer.PhoneHome = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid phone number, please input again");
                }
            }
        }

        internal void ShowEnteringIdToDelete()
        {
            Console.Write("Input id customer to delete: ");
            _enteringNumber = Convert.ToInt32(Console.ReadLine());
        }

        public Customer GetEnteringCustomer()
        {
            return _customer;
        }

        internal bool IsConfirmed()
        {
            Console.WriteLine("Are you sure want to delete! 1. YES          2. NO");
            _enteringNumber = Convert.ToInt32(Console.ReadLine());
            if (_enteringNumber == 1)
            {
                return true;
            }
            return false;
        }

        public void ShowCustomer(Customer _customer)
        {
            Console.WriteLine("Id: {0}", _customer.Id);
            Console.WriteLine("Name: {0}", _customer.Name);
            Console.WriteLine("Email Office: {0}", _customer.EmailOffice);
            Console.WriteLine("Phone Office: {0}", _customer.PhoneOffice);
            Console.WriteLine("Email Home: {0}", _customer.EmailHome);
            Console.WriteLine("Phone Home: {0}", _customer.PhoneHome);
        }

        public void Inform(string v)
        {
            Console.WriteLine(v);
        }

        public void ShowOptionViewCustomer()
        {
            Console.WriteLine("====>Menu show customer<====");
            Console.WriteLine("41. Show all customers");
            Console.WriteLine("42. Show a customer");
            Console.WriteLine("Your selection: ");
            _enteringNumber = Convert.ToInt32(Console.ReadLine());
        }

        internal void ShowEnteringIdToView()
        {
            Console.Write("Input id customer to View: ");
            _enteringNumber = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowAllCustomers(List<Customer> listCustomer)
        {            
            foreach(var item in listCustomer)
            {
                ShowCustomer(item);
            }
        }
    }
}