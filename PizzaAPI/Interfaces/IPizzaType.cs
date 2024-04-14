using PizzaAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaAPI.Models;

namespace PizzaAPI.Interfaces
{
    public interface IPizzaType
    {
       ServiceResponse<List<PizzaTypeDTO>> GetAll();
          ServiceResponse<PizzaTypeDTO> GetById(string pizza_type_id);
          ServiceResponse<PizzaTypeDTO> AddPizzaType(PizzaTypeDTO model);
          ServiceResponse<PizzaTypeDTO> DeletePizzaType(PizzaTypeDTO model);
          ServiceResponse<PizzaTypeDTO> UpdatePizzaType(PizzaTypeDTO model);
    }
}
