using Digi.Infra.Interfaces;
using Digi.Infra.Records;
using Microsoft.AspNetCore.Mvc;

namespace Digi.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TamerController : ControllerBase
    {
        private readonly IQueryTamerService _queryS;

        public TamerController(IQueryTamerService queryS)
        {
            _queryS = queryS;
        }

        [HttpGet]
        public async Task<IEnumerable<TamerRecord>> GetAll()
        {
            return await _queryS.GetAllAsync();
        }
    }
}