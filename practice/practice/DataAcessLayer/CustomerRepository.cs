using Microsoft.EntityFrameworkCore;
using practice.Context;
using practice.Model;

namespace practice.DataAcessLayer
{
    public class CustomerRepository : ICustomerRepisitory
    {
        public readonly DeliveryDBContext context;

        public CustomerRepository(DeliveryDBContext _context)
        {
            context = _context;
        }

        // get customer from database //
        public async Task<List<Customer>> GetAllCustomer()
        {
           var customerList = await context.Customers.ToListAsync();
            return customerList;
        }


        // Add customer
        public async Task AddCustomer_Repo(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }


        // delete customers

        public async Task<string> DeleteCustomer_Repo(int _customerId)
        {
            Customer foundCustomer = await context.Customers.FindAsync(_customerId);

            if (foundCustomer == null) return "Customer with the give ID not found";

        
            context.Customers.Remove(foundCustomer);
            await context.SaveChangesAsync();
            return "Customer deleted succesfully!";

        }

        // update //
        public Task<Customer> GetCustomerByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> UpdateCustomer_Repo(int customerId, string _customerName)
        {
            var getcustomer = await context.Customers.FindAsync(customerId);

            if (getcustomer == null) return null;

            if (getcustomer != null)
            {
                getcustomer.Customer_Name = _customerName;
                context.SaveChanges();
            }

            return getcustomer;
        }
    }
}
