using MyFinance.Webapi.Models.Domains;
using MyFinance.Webapi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Webapi.Models.Converters
{
    public static class OperationConverter
    {

        public static OperationDto ToDto(this Operations model)
        {
            return new OperationDto
            {
                CategoryId = model.CategoryId,
                Data = model.Data,
                Description = model.Description,
                Id=model.Id,
                Name=model.Name,
                Value=model.Value
            };
        }

        public static IEnumerable<OperationDto> ToDtos(this IEnumerable<Operations> model)
        {
            if (model==null)
           
                return Enumerable.Empty<OperationDto>();

            return model.Select(x => x.ToDto());
        }

        public static Operations ToDao(this OperationDto  model)
        {
            return new Operations
            {
                CategoryId = model.CategoryId,
                Data = model.Data,
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
                Value = model.Value
            };
        }
    }
}
