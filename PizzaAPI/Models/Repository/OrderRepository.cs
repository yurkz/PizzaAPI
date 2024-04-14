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
    public class OrderRepository : IOrder
    {
        Mapper map = new Mapper();
        PizzaRepository pizzaRepo = new PizzaRepository();
        OrderDetailsRepository orderDetailsRepo = new OrderDetailsRepository();

        public ServiceResponse<AddOrderDTO> AddOrder(AddOrderDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<AddOrderDTO>();
                    try
                    {
                        PizzaDTO pizzaDTO = new PizzaDTO
                        {
                            pizza_id = model.pizza
                        };

                        var pizzaDetails = pizzaRepo.GetById(pizzaDTO);

                        DateTime dateTime = DateTime.Now;
                        DateTime datePart = dateTime.Date;
                        TimeSpan timePart = dateTime.TimeOfDay;
                        string formattedTime = timePart.ToString(@"hh\:mm\:ss\.fffffff");
                        TimeSpan parsedTimeSpan = TimeSpan.Parse(formattedTime);
                        order order = new order
                        {
                            date = datePart,
                            time = parsedTimeSpan
                        };

                        db.orders.Add(order);
                        db.SaveChanges();

                        OrderDetailsDTO orderDetailsDTO = new OrderDetailsDTO
                        {
                            order_id = order.order_id,
                            pizza_id = pizzaDetails.Data.pizza_id,
                            quantity = model.quantity
                        };

                        ts.Commit();

                        var response = orderDetailsRepo.AddOrderDetails(orderDetailsDTO);
                        if (!response.Success)
                            throw new Exception(response.Message);
                        
                        
                        serviceResponse.Data = map.MapToDto<AddOrderDTO>(model);
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

        public ServiceResponse<OrderDTO> DeleteOrder(OrderDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<OrderDTO>();
                    try
                    {

                        var pizza = db.orders.Where(a => a.order_id == model.order_id).SingleOrDefault();
                        if (pizza == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }


                        order orders = db.orders.Where(a => a.order_id == model.order_id).SingleOrDefault();

                        db.orders.Remove(orders);

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<OrderDTO>(pizza);
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

        public ServiceResponse<List<OrderDTO>> GetAll()
        {
            using (var db = new PizzaEntities())
            {
              
                    var serviceResponse = new ServiceResponse<List<OrderDTO>>();

                    var orders = db.orders.ToList();
                    List<OrderDTO> list = new List<OrderDTO>();

                    foreach (var item in orders)
                    {
                        OrderDTO dto = new OrderDTO()
                        {
                            date = item.date,
                            time = item.time,
                            order_id = item.order_id
                        };

                        list.Add(dto);
                    }
                    serviceResponse.Data = list;
                    return serviceResponse;
              
            }
        }

        public ServiceResponse<OrderDTO> GetById(OrderDTO model)
        {
            using (var db = new PizzaEntities())
            {
               
                    var serviceResponse = new ServiceResponse<OrderDTO>();
                    var order = db.orders.Where(a => a.order_id == model.order_id).SingleOrDefault();
                    if (order == null)
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "No Data Found";
                        return serviceResponse;
                    }

                    serviceResponse.Data = map.MapToDto<OrderDTO>(order);

                    return serviceResponse;
               
            }
        }

        public ServiceResponse<OrderDTO> UpdateOrder(OrderDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<OrderDTO>();
                    try
                    {
                        var order = db.orders.Where(a => a.order_id == model.order_id).SingleOrDefault();
                        if (order == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }

                        order.date = model.date;
                        order.time = model.time;

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<OrderDTO>(order);
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