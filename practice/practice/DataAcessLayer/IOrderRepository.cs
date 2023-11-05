using practice.Model;

namespace practice.DataAcessLayer
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
    }
}
