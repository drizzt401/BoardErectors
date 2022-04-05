using BoardErectors.Application.Responses;
using BoardErectors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardErectors.Application.EstateAgentProperties.Queries
{
    public class EstateAgentPropertiesQuery : IRequest<PropertiesResponseModel>
    {
        public string AccountCode { get; set; }
    }
}
