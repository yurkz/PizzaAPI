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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        OrderRepository repo = new OrderRepository();


        [HttpGet]
        [Route("")]
        public ServiceResponse<List<OrderDTO>> GetAll()
        {
            return repo.GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public ServiceResponse<OrderDTO> GetById(OrderDTO model)
        {
            return repo.GetById(model);
        }


        [HttpPost]
        [Route("")]
        public ServiceResponse<AddOrderDTO> AddPizza(AddOrderDTO model)
        {
            return repo.AddOrder(model);
        }

        [HttpDelete]
        [Route("")]
        public ServiceResponse<OrderDTO> DeletePizza(OrderDTO model)
        {
            return repo.DeleteOrder(model);
        }


        [HttpPut]
        [Route("")]
        public ServiceResponse<OrderDTO> UpdatePizza(OrderDTO model)
        {
            return repo.UpdateOrder(model);
        }



    }
}
