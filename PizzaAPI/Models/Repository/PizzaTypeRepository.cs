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
    public class PizzaTypeRepository : IPizzaType
    {
        Mapper map = new Mapper();

        public ServiceResponse<PizzaTypeDTO> AddPizzaType(PizzaTypeDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaTypeDTO>();
                    try
                    {
                        pizza_types pizzaType = map.Map<pizza_types>(model);
                        db.pizza_types.Add(pizzaType);
                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<PizzaTypeDTO>(pizzaType);
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

        public ServiceResponse<PizzaTypeDTO> DeletePizzaType(PizzaTypeDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaTypeDTO>();
                    try
                    {

                        var pizzaType = db.pizza_types.Where(a => a.pizza_type_id == model.pizza_type_id).SingleOrDefault();
                        if (pizzaType == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }


                        pizza_types pizza_Types = db.pizza_types.Where(a => a.pizza_type_id == model.pizza_type_id).SingleOrDefault();

                        db.pizza_types.Remove(pizza_Types);

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<PizzaTypeDTO>(pizza_Types);
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

        public ServiceResponse<List<PizzaTypeDTO>> GetAll()
        {
            using (var db = new PizzaEntities())
            {

                var serviceResponse = new ServiceResponse<List<PizzaTypeDTO>>();

                var pizza_types = db.pizza_types.ToList();
                List<PizzaTypeDTO> list = new List<PizzaTypeDTO>();

                foreach (var item in pizza_types)
                {
                    PizzaTypeDTO dto = new PizzaTypeDTO()
                    {
                        category = item.category,
                        ingredients = item.ingredients,
                        name = item.name,
                        pizza_type_id = item.pizza_type_id
                    };

                    list.Add(dto);
                }
                serviceResponse.Data = list;
                return serviceResponse;

            }
        }

        public ServiceResponse<PizzaTypeDTO> GetById(string pizza_type_id)
        {
            using (var db = new PizzaEntities())
            {

                var serviceResponse = new ServiceResponse<PizzaTypeDTO>();
                var pizzaType = db.pizza_types.Where(a => a.pizza_type_id == pizza_type_id).SingleOrDefault();
                if (pizzaType == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "No Data Found";
                    return serviceResponse;
                }

                serviceResponse.Data = map.MapToDto<PizzaTypeDTO>(pizzaType);

                return serviceResponse;

            }
        }

        public ServiceResponse<PizzaTypeDTO> UpdatePizzaType(PizzaTypeDTO model)
        {
            using (var db = new PizzaEntities())
            {
                using (var ts = db.Database.BeginTransaction())
                {
                    var serviceResponse = new ServiceResponse<PizzaTypeDTO>();
                    try
                    {
                        var pizzaType = db.pizza_types.Where(a => a.pizza_type_id == model.pizza_type_id).SingleOrDefault();
                        if (pizzaType == null)
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = "No Data Found";
                            return serviceResponse;
                        }

                        pizzaType.category = model.category;
                        pizzaType.ingredients = model.ingredients;
                        pizzaType.name = model.name;

                        db.SaveChanges();

                        ts.Commit();

                        serviceResponse.Data = map.MapToDto<PizzaTypeDTO>(pizzaType);
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