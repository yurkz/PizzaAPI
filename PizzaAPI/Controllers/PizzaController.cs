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
    [RoutePrefix("api/pizza")]
    public class PizzaController : ApiController
    {
        PizzaRepository repo = new PizzaRepository();


        [HttpGet]
        [Route("")]
        public ServiceResponse<List<PizzaDTO>> GetAll()
        {
            return repo.GetAll();
        }

        [HttpGet]
        [Route("{pizzaTypeId}")]
        public ServiceResponse<PizzaDTO> GetById(string pizzaId)
        {
            return repo.GetById(pizzaId);
        }


        [HttpPost]
        [Route("")]
        public ServiceResponse<PizzaDTO> AddPizza(PizzaDTO model)
        {
            return repo.AddPizza(model);
        }

        [HttpDelete]
        [Route("")]
        public ServiceResponse<PizzaDTO> DeletePizza(PizzaDTO model)
        {
            return repo.DeletePizza(model);
        }


        [HttpPut]
        [Route("")]
        public ServiceResponse<PizzaDTO> UpdatePizza(PizzaDTO model)
        {
            return repo.UpdatePizza(model);
        }



    }
}
