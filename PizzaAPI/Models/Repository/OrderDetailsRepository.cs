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
    public class OrderDetailsRepository : IOrderDetails
    {
        Mapper map = new Mapper();
       

        public ServiceResponse<OrderDetailsDTO> AddOrderDetails(OrderDetailsDTO model)
        {
            using (var db = new PizzaEntities())
            {
                db.Database.CommandTimeout = 300; 

                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<OrderDetailsDTO>();
                    try
                    {
                        order_details order_Details = new order_details
                        {
                            order_id = model.order_id,
                            //order = db.orders.Where(a => a.order_id == model.order_id).SingleOrDefault(),
                            pizza_id = model.pizza_id,
                            quantity = model.quantity
                        };

                        db.order_details.Add(order_Details);

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<OrderDetailsDTO>(order_Details);
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

        public ServiceResponse<OrderDetailsDTO> DeleteOrderDetails(OrderDetailsDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<OrderDetailsDTO>();
                    try
                    {

                        var order = db.order_details.Where(a => a.order_details_id == model.order_details_id).SingleOrDefault();
                        if (order == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }


                        order_details order_details = db.order_details.Where(a => a.order_details_id == model.order_details_id).SingleOrDefault();

                        db.order_details.Remove(order_details);

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<OrderDetailsDTO>(order);
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

        public ServiceResponse<List<OrderDetailsDTO>> GetAll()
        {
            using (var db = new PizzaEntities())
            {

                    var serviceResponse = new ServiceResponse<List<OrderDetailsDTO>>();

                    var order_details = db.order_details.ToList();
                    List<OrderDetailsDTO> list = new List<OrderDetailsDTO>();

                    foreach (var item in order_details)
                    {
                        OrderDetailsDTO dto = new OrderDetailsDTO()
                        {
                            order_id = item.order_id,
                            pizza_id = item.pizza_id,
                            order_details_id = item.order_details_id,
                            quantity = item.quantity
                        };

                        list.Add(dto);
                    }
                    serviceResponse.Data = list;
                    return serviceResponse;
           
            }
        }

        public ServiceResponse<OrderDetailsDTO> GetById(long order_details_id)
        {
            using (var db = new PizzaEntities())
            {
              
                    var serviceResponse = new ServiceResponse<OrderDetailsDTO>();
                    var order_details = db.order_details.Where(a => a.order_details_id == order_details_id).SingleOrDefault();
                    if (order_details == null)
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "No Data Found";
                        return serviceResponse;
                    }

                    serviceResponse.Data = map.MapToDto<OrderDetailsDTO>(order_details);

                    return serviceResponse;
               
            }
        }

        public ServiceResponse<OrderDetailsDTO> UpdateOrderDetails(OrderDetailsDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<OrderDetailsDTO>();
                    try
                    {
                        var order_details = db.order_details.Where(a => a.order_details_id == model.order_details_id).SingleOrDefault();
                        if (order_details == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }

                        order_details.order_id = model.order_id;
                        order_details.pizza_id = model.pizza_id;
                        order_details.quantity = model.quantity;

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<OrderDetailsDTO>(order_details);
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