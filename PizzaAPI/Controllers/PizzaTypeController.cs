using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PizzaAPI.DTOs;
using PizzaAPI.Models;
using PizzaAPI.Models.Repository;

namespace PizzaAPI.Controllers
{
    [RoutePrefix("api/pizzatype")]
    public class PizzaTypeController : ApiController
    {
        PizzaTypeRepository repo = new PizzaTypeRepository();


        [HttpGet]
        [Route("")]
        public ServiceResponse<List<PizzaTypeDTO>> GetAll()
        {
            return repo.GetAll();
        }

        [HttpGet]
        [Route("{pizzaTypeId}")]
        public ServiceResponse<PizzaTypeDTO> GetById(string pizzaTypeId)
        {
            return repo.GetById(pizzaTypeId);
        }


        [HttpPost]
        [Route("")]
        public ServiceResponse<PizzaTypeDTO> AddPizzaType(PizzaTypeDTO model)
        {
            return repo.AddPizzaType(model);
        }

        [HttpDelete]
        [Route("")]
        public ServiceResponse<PizzaTypeDTO> DeletePizzaType(PizzaTypeDTO model)
        {
            return repo.DeletePizzaType(model);
        }


        [HttpPut]
        [Route("")]
        public ServiceResponse<PizzaTypeDTO> UpdatePizzaType(PizzaTypeDTO model)
        {
            return repo.UpdatePizzaType(model);
        }



    }
}
