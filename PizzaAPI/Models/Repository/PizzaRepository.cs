using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PizzaAPI.DTOs;
using PizzaAPI.Interfaces;
using PizzaAPI.Utility;

namespace PizzaAPI.Models.Repository
{
    public class PizzaRepository : IPizza
    {
        Mapper map = new Mapper();

        public ServiceResponse<PizzaDTO> AddPizza(PizzaDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaDTO>();
                    try
                    {
                        pizza pizza = map.Map<pizza>(model);
                        db.pizzas.Add(pizza);
                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<PizzaDTO>(pizza);
                        return serviceResponse;
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        serviceResponse.Message = e.Message;
                        serviceResponse.Success = false;
                        return serviceResponse;

                    }
                }
            }
        }

        public ServiceResponse<PizzaDTO> DeletePizza(PizzaDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaDTO>();
                    try
                    {

                        var pizza = db.pizzas.Where(a => a.pizza_id == model.pizza_id).SingleOrDefault();
                        if (pizza == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }


                        pizza pizzas = db.pizzas.Where(a => a.pizza_id == model.pizza_id).SingleOrDefault();

                        db.pizzas.Remove(pizzas);

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<PizzaDTO>(pizza);
                        return serviceResponse;
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        serviceResponse.Success = false;
                        serviceResponse.Message = e.Message;
                        return serviceResponse;
                    }
                }
            }
        }

        public ServiceResponse<List<PizzaDTO>> GetAll()
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<List<PizzaDTO>>();

                    var pizza = db.pizzas.ToList();
                    List<PizzaDTO> list = new List<PizzaDTO>();

                    foreach (var item in pizza)
                    {
                        PizzaDTO dto = new PizzaDTO()
                        {
                            pizza_type_id = item.pizza_type_id,
                            price = item.price,
                            size = item.size,
                            pizza_id = item.pizza_id
                        };

                        list.Add(dto);
                    }
                    serviceResponse.Data = list;
                    return serviceResponse;
                }
            }
        }

        public ServiceResponse<PizzaDTO> GetById(string pizza_id)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaDTO>();
                    var pizza = db.pizzas.Where(a => a.pizza_id == pizza_id).SingleOrDefault();
                    if (pizza == null)
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "No Data Found";
                        return serviceResponse;
                    }

                    serviceResponse.Data = map.MapToDto<PizzaDTO>(pizza);

                    return serviceResponse;
                }
            }
        }

        public ServiceResponse<PizzaDTO> UpdatePizza(PizzaDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaDTO>();
                    try
                    {
                        var pizza = db.pizzas.Where(a => a.pizza_id == model.pizza_id).SingleOrDefault();
                        if (pizza == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }

                        pizza.pizza_type_id = model.pizza_type_id;
                        pizza.price = model.price;
                        pizza.size = model.size;

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<PizzaDTO>(pizza);
                        return serviceResponse;
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        serviceResponse.Success = false;
                        serviceResponse.Message = e.Message;
                        return serviceResponse;

                    }
                }
            }
        }




    }
}