using BoardErectors.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardErectors.Application.Services
{
    public interface IPropertyService
    {
        //Task<IEnumerable<Property>> GetProperties();
        Task<(IEnumerable<Property>, string)> GetPropertiesByAgentCode(string accountCode);
    }
}
