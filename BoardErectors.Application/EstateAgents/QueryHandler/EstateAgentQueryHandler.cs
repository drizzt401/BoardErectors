using BoardErectors.Application.EstateAgents.Queries;
using BoardErectors.Application.Services;
using BoardErectors.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoardErectors.Application.EstateAgents.QueryHandler
{
    public class EstateAgentQueryHandler : IRequestHandler<EstateAgentQuery, Agent>
    {
        private readonly IEstateAgentAccountService _estateAgentAccountService;

        public EstateAgentQueryHandler(IEstateAgentAccountService estateAgentAccountService)
        {
            _estateAgentAccountService = estateAgentAccountService;
        }
        public async Task<Agent> Handle(EstateAgentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var agent = await _estateAgentAccountService.GetAgentDetails(request.AccountCode);
                return agent;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
