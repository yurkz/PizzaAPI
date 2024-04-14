using PizzaAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IPizza
    {
        ServiceResponse<List<PizzaDTO>> GetAll();
        ServiceResponse<PizzaDTO> GetById(string pizza_id);
        ServiceResponse<PizzaDTO> AddPizza(PizzaDTO model);
        ServiceResponse<PizzaDTO> DeletePizza(PizzaDTO model);
        ServiceResponse<PizzaDTO> UpdatePizza(PizzaDTO model);
    }
}
