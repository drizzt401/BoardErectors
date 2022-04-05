using BoardErectors.Application.EstateAgentProperties.Queries;
using BoardErectors.Web.Models;
using BoardErectors.Web.Models.Home;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BoardErectors.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediatR;

        public HomeController(ILogger<HomeController> logger, IMediator mediatR)
        {
            _logger = logger;
            _mediatR = mediatR;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string AccountCode)
        {
            var response = await _mediatR.Send(new EstateAgentPropertiesQuery { AccountCode = AccountCode });
            return View(new HomeViewModel { Properties = response.Properties, Message = response.Message});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
