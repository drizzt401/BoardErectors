using BoardErectors.Domain.Entities;
using System.Threading.Tasks;

namespace BoardErectors.Application.Services
{
    public interface IEstateAgentAccountService
    {
        //Task<IEnumerable<Agent>> GetAgents();
        Task<Agent> GetAgentDetails(string accountCode);
    }
}
