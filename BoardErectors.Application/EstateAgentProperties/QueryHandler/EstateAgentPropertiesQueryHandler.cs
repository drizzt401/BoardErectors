using BoardErectors.Application.EstateAgentProperties.Queries;
using BoardErectors.Application.Responses;
using BoardErectors.Application.Services;
using BoardErectors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoardErectors.Application.EstateAgentProperties.QueryHandler
{
    public class EstateAgentPropertiesQueryHandler : IRequestHandler<EstateAgentPropertiesQuery, PropertiesResponseModel>
    {
        private readonly IPropertyService _propertyService;

        public EstateAgentPropertiesQueryHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        public async Task<PropertiesResponseModel> Handle(EstateAgentPropertiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _propertyService.GetPropertiesByAgentCode(request.AccountCode);
                return new PropertiesResponseModel { Properties= result.Item1, Message = result.Item2 };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
