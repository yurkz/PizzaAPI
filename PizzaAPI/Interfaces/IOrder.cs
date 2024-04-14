using PizzaAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IOrder
    {
        ServiceResponse<List<OrderDTO>> GetAll();
        ServiceResponse<OrderDTO> GetById(OrderDTO model);
        ServiceResponse<AddOrderDTO> AddOrder(AddOrderDTO model);
        ServiceResponse<OrderDTO> DeleteOrder(OrderDTO model);
        ServiceResponse<OrderDTO> UpdateOrder(OrderDTO model);
    }
}
