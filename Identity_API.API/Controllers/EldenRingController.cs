using Identity_API.DAL;
using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EldenRingController : ControllerBase
    {
        private readonly IDbManager _dbManager;

        public EldenRingController(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<List<EldenRingWeapon>>> GetWeapons(string accessToken)
        {
            bool accessTokenFound = _dbManager.GetCurrentUserAccessToken(accessToken);

            if (accessTokenFound is false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            return _dbManager.GetWeapons();
        }
    }
}
