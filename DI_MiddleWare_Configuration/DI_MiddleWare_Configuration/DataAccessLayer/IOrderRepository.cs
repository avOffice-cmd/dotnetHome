using DI_MiddleWare_Configuration.DTO;
using DI_MiddleWare_Configuration.Models;

namespace DI_MiddleWare_Configuration.DataAccessLayer
{
    public interface IOrderRepository
    {
        Task AddCustomerOrder(Customer customer);
        Task AddOrder(Order order);
        Task<Order> GetOrderById(int orderId);
        Task UpdateOrder(Order order);
        Task<List<CustomerOrderViewDTO>> GetCustomerOrders(int customerId);
    }
}
