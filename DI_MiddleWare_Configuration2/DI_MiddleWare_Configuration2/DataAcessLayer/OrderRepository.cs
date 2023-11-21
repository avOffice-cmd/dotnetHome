using DI_MiddleWare_Configuration2.Context;
using DI_MiddleWare_Configuration2.Models;
using Microsoft.EntityFrameworkCore;

namespace DI_MiddleWare_Configuration2.DataAcessLayer
{
    public class OrderRepository : IorderRepository
    {
        private readonly MyDbContext context;
        public OrderRepository(MyDbContext deliveryDBContext)
        {
            context = deliveryDBContext;
        }

        // ADD //
        public async Task AddOrder_Repo(Order order)
        {

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }


        // UPDATE ORDERS

        public async Task<Order> UpdateOrder_Repo(int orderId, string _orderStatus)
        {
            var getorder = await context.Orders.FindAsync(orderId);

            if (getorder == null) return null;

            if (getorder != null)
            {
                getorder.OrderStatus = _orderStatus;
                if(_orderStatus == "Delivered")
                {
                    getorder.DeliveryDate = DateTime.Now;
                }
                context.SaveChanges();
            }

            return getorder;
        }


        // DELETE ORDERS

        public async Task<Order> GetOrderByID(int _orderID)
        {
            var foundOrder = await context.Orders.FindAsync(_orderID);

            return foundOrder;
        }

        public async Task<string> DeleteOrder_Repo(int _orderId)
        {
            Order foundOrder = await context.Orders.FindAsync(_orderId);

            if (foundOrder == null) return "Order with the give ID not found";


            context.Orders.Remove(foundOrder);
            await context.SaveChangesAsync();
            return "Order deleted succesfully!";

        }




        // GET ALL ORDERS
        public async Task<List<Order>> GetAllOrders()
        {
            var orderTable = await context.Orders.ToListAsync();
            return orderTable;
        }



    }
}
