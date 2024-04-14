using PizzaAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IOrderDetails
    {
        ServiceResponse<List<OrderDetailsDTO>> GetAll();
        ServiceResponse<OrderDetailsDTO> GetById(long order_detail_id);
        ServiceResponse<OrderDetailsDTO> AddOrderDetails(OrderDetailsDTO model);
        ServiceResponse<OrderDetailsDTO> DeleteOrderDetails(OrderDetailsDTO model);
        ServiceResponse<OrderDetailsDTO> UpdateOrderDetails(OrderDetailsDTO model);
    }
}
