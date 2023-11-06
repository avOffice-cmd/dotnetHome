using DI_MiddleWare_Configuration.Context;
using DI_MiddleWare_Configuration.DTO;
using DI_MiddleWare_Configuration.Helper;
using DI_MiddleWare_Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace DI_MiddleWare_Configuration.DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task AddCustomerOrder(Customer customer)
        {
            
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task<Order> GetOrderById(int orderId) =>
            await (_context.Orders.SingleOrDefaultAsync(o => o.Id == orderId));

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.UpdateRange(order);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CustomerOrderViewDTO>> GetCustomerOrders(int customerId)
        {
            var customerInfo = _context.Customers.Where(c=>c.Id== customerId)
                .Include(c => c.Orders)
                .Select(c =>
            new CustomerOrderViewDTO
            {
                FirstName = c.Name.Split(" ", StringSplitOptions.None).FirstOrDefault(),
                LastName = c.Name.Split(" ", StringSplitOptions.None).LastOrDefault(),
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Orders = c.Orders.Select(ord => new OrderViewDTO
                {
                    InvoiceId = ord.InvoiceId,
                    DeliveryCity = ord.DeliveryCity,
                    OrderDate = ord.OrderDate,
                    DeliveryDate = ord.DeliveryDate,
                    Quantity = ord.Quantity,
                    OrderStatus = ord.OrderStatus,
                    Total_Amt = ord.Total_Amt
                }).ToList()
            }).ToList();
            return customerInfo;
        }
    }
}
