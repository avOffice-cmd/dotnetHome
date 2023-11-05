using practice.Model;

namespace practice.DataAcessLayer
{
    public interface ICustomerRepisitory
    {
        Task<List<Customer>> GetAllCustomer();

        Task AddCustomer_Repo(Customer customer);

        Task<string> DeleteCustomer_Repo(int _customerId);
        Task<Customer> GetCustomerByID(int customerId);
        Task<Customer> UpdateCustomer_Repo(int customerId, string customerName);
    }
}
