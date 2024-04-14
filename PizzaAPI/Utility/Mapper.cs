using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;


namespace PizzaAPI.Utility
{
    public class Mapper
    {
        public T Map<T>(object dto) where T : new()
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            T model = new T();
            PropertyInfo[] dtoProperties = dto.GetType().GetProperties();
            PropertyInfo[] modelProperties = typeof(T).GetProperties();

            foreach (var dtoProp in dtoProperties)
            {
                var modelProp = Array.Find(modelProperties, p => p.Name == dtoProp.Name && p.PropertyType == dtoProp.PropertyType);
                if (modelProp != null && modelProp.CanWrite)
                {
                    var value = dtoProp.GetValue(dto);
                    modelProp.SetValue(model, value);
                }
            }
            return model;
        }


        public T MapToDto<T>(object model) where T : new()
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            T dto = new T();
            PropertyInfo[] modelProperties = model.GetType().GetProperties();
            PropertyInfo[] dtoProperties = typeof(T).GetProperties();

            foreach (var modelProp in modelProperties)
            {
                var dtoProp = Array.Find(dtoProperties, p => p.Name == modelProp.Name);
                if (dtoProp != null && dtoProp.CanWrite)
                {
                    var value = modelProp.GetValue(model);
                    dtoProp.SetValue(dto, value);
                }
            }

            return dto;
        }


    }
}