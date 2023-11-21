using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.Models;

namespace DI_MiddleWare_Configuration2.DataAcessLayer
{
    public interface IorderRepository
    {
        Task AddOrder_Repo(Order order);

        Task<Order> UpdateOrder_Repo(int orderId, string _orderStatus);

        Task<Order> GetOrderByID(int _orderID);
        Task<string> DeleteOrder_Repo(int _orderId);

        //Task<List<Order>> GetAllOrder();
        Task<List<Order>> GetAllOrders();

     
    }
}
