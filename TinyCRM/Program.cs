using System;
using System.Collections.Generic;

namespace TinyCRM
{
    class Program
    {
        static int Main(string[] args)
        {
            var ui = new UserInterface();
            var logic = new CustomerService();

            while (true)
            {
                ui.ShowMainMenu();
                int selectedItem = ui.GetEnteringInputNumber();

                switch (selectedItem)
                {
                    case 1: //Add new customer
                        ui.ShowEnteringCustomer();
                        Customer newCustomer = new Customer();
                        newCustomer = ui.GetEnteringCustomer();
                        //check duplicate customer
                        if (logic.IsValidCustomerByCustomer(newCustomer))
                        {
                            logic.Save(newCustomer);
                            ui.Inform("Added a new customer!");
                        }
                        else
                        {
                            ui.Inform("Customer is already exist");
                        }

                        break;
                    case 2: //Edit a customer
                        ui.ShowEnteringIdToEdit();
                        int idCustomerEdit = ui.GetEnteringInputNumber();

                        Customer editCustomer = new Customer();
                        editCustomer = logic.GetCustomerById(idCustomerEdit);
                        ui.ShowCustomer(editCustomer);
                        ui.Inform("===>Start update customer");
                        ui.ShowEnteringCustomer();
                        editCustomer = ui.GetEnteringCustomer();
                        if (logic.IsValidEmail(editCustomer.EmailHome) && logic.IsValidEmail(editCustomer.EmailOffice))
                        {
                            logic.Save(editCustomer);
                            ui.Inform("Updated!");
                        }
                        else
                        {
                            ui.Inform("Invalid email address!");
                        }
                        break;
                    case 3: //delete a customer
                        ui.ShowEnteringIdToDelete();
                        int idCustomerDelete = ui.GetEnteringInputNumber();
                        if (logic.IsValidCustomerById(idCustomerDelete))
                        {
                            if (ui.IsConfirmed())
                            {
                                logic.DeleteById(idCustomerDelete);
                                ui.Inform("Customer is deleted!");
                            }
                        }
                        else
                        {
                            ui.Inform("Invalid Customer Id!");
                        }
                        break;
                    case 4: //view customers
                        ui.ShowOptionViewCustomer();
                        int selectView = ui.GetEnteringInputNumber();
                        switch (selectView)
                        {
                            case 41: //show all customers
                                List<Customer> listCustomer = new List<Customer>();
                                listCustomer = logic.GetAllCustomers();
                                ui.ShowAllCustomers(listCustomer);
                                break;
                            case 42: //show a customer
                                ui.ShowEnteringIdToView();
                                int idCustomerShow = ui.GetEnteringInputNumber();
                                if (logic.IsValidCustomerById(idCustomerShow))
                                {
                                    Customer customerShow = new Customer();
                                    customerShow = logic.GetCustomerById(idCustomerShow);
                                    ui.ShowCustomer(customerShow);
                                }
                                else
                                {
                                    ui.Inform("Invalid Customer Id!");

                                }
                                break;
                        }
                        break;
                    case 5: //quit
                        return 0;
                    default:
                        ui.Inform("Bad selection");
                        break;
                }
            }

        }
    }
}
