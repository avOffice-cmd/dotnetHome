using DI_MiddleWare_Configuration2.Context;
using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;
using Microsoft.EntityFrameworkCore;

namespace DI_MiddleWare_Configuration2.DataAcessLayer
{
    public class CustomerRepository : IcustomerRepository
    {
        private readonly MyDbContext context;
       
        public CustomerRepository(MyDbContext deliveryDBContext)
        {
            context = deliveryDBContext;
        }

        // ADD //
        public async Task AddCustomer_Repo(Customer customer)
        {

            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        // update //
        public async Task<Customer> UpdateCustomer_Repo(int customerId, string _customerName)
        {
            var getcustomer = await context.Customers.FindAsync(customerId);

            if (getcustomer == null) return null;

            if (getcustomer != null)
            {
                getcustomer.Name = _customerName;
                context.SaveChanges();
            }

            return getcustomer;
        }


        // delete

        public async Task<Customer> GetCustomerByID(int _customerID)
        {
            var foundCustomer = await context.Customers.FindAsync(_customerID);

            return foundCustomer;
        }

        public async Task<string> DeleteCustomer_Repo(int _customerId)
        {
            Customer foundCustomer = await context.Customers.FindAsync(_customerId);

            if (foundCustomer == null) return "Customer with the give ID not found";

          
            context.Customers.Remove(foundCustomer);
            await context.SaveChangesAsync();
            return "Customer deleted succesfully!";

        }


        // get
        public async Task<List<Customer>> GetAllCustomers()
        {
            var customersTable = await context.Customers.ToListAsync();
            return customersTable;
        }


        // getcustomerOrderById

        // GetCustomerOrdersBYID //

        //public async Task<List<customerSpecifcOrdersDTO>> GetCustomerOrders(int customerId)
        //{
        //    var customerInfo = context.Customers.Where(c => c.Id == customerId)
        //        .Include(c => c.Orders)
        //        .Select(c =>
        //    new customerSpecifcOrdersDTO
        //    {
        //        customerName = c.Name,

        //        customer_Orders = c.Orders.Select(ord => new OrderViewDTO
        //        {
        //            InvoiceId = ord.InvoiceId,
        //            DeliveryCity = ord.DeliveryCity,
        //            OrderDate = ord.OrderDate,
        //            DeliveryDate = ord.DeliveryDate,
        //            Quantity = ord.Quantity,
        //            OrderStatus = ord.OrderStatus,
        //            Total_Amt = ord.Total_Amt
        //        }).ToList()
        //    }).ToList();
        //    return customerInfo;
        //}


    }
}
