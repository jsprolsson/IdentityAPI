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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EldenRingWeapon))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<ActionResult<EldenRingWeapon>> GetWeapons(int id, string accessToken)
        {
            bool accessTokenFound = _dbManager.GetCurrentUserAccessToken(accessToken);

            if (accessTokenFound is false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            return _dbManager.GetWeapon(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<IActionResult> PostWeapon(EldenRingWeapon weapon, string accessToken)
        {
            bool accessTokenFound = _dbManager.GetCurrentUserAccessToken(accessToken);

            if (accessTokenFound is false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            await _dbManager.PostWeapon(weapon);
            return Ok("Weapon added");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<IActionResult> UpdateWeapon(EldenRingWeapon weapon, string accessToken)
        {
            bool accessTokenFound = _dbManager.GetCurrentUserAccessToken(accessToken);

            if (accessTokenFound is false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            await _dbManager.UpdateWeapon(weapon);
            return Ok("Weapon updated");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        public async Task<IActionResult> DeleteWeapon(int id, string accessToken)
        {
            bool accessTokenFound = _dbManager.GetCurrentUserAccessToken(accessToken);

            if (accessTokenFound is false)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            await _dbManager.DeleteWeapon(id);
            return Ok("Weapon deleted");
        }

    }
}
