using BoardErectors.Domain.Entities;
using MediatR;

namespace BoardErectors.Application.EstateAgents.Queries
{
    public class EstateAgentQuery : IRequest<Agent>
    {
        public string AccountCode { get; set; }
    }
}
