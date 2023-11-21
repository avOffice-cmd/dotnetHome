using DI_MiddleWare_Configuration2.DTO;
using DI_MiddleWare_Configuration2.DTO.OrderStatusDTO;
using DI_MiddleWare_Configuration2.Models;
using static DI_MiddleWare_Configuration2.Service.CustomerService;
using static DI_MiddleWare_Configuration2.Service.OrderService;

namespace DI_MiddleWare_Configuration2.Service
{
    public interface IOrderService
    {
        Task AddOrder_Service(OrderDTO addOrderDTO);

        Task<Order> UpdateOrder_Service(int _orderId, string _orderStatus);

        Task<string> DeleteOrder_Service(int _orderId);
        Task<OrderResult> GetAllOrders();

        Task<List<FetchAllOrdersByCityDTO>> GetallOrdersBySpecificCity();

        Task<List<FetchAllOrdersByOredrStatusDTO>> GetallOrdersBySpecificStatus();


        Task<List<GetAllInvoiceIdBySpecificCityDTO>> GetallInvoiceIdBySpecificCity();




    }
}
