using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using practice.Context;
using practice.Model;

namespace practice.DataAcessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DeliveryDBContext context;
        public OrderRepository(DeliveryDBContext ordersDBContext)
        {
            context = ordersDBContext;
        }
        public async Task<List<Order>> GetAllOrders()
        {
           var gotOrders = await context.Orders.ToListAsync();

            if (gotOrders == null)
                return null;

            return gotOrders;

        }
    }
}
