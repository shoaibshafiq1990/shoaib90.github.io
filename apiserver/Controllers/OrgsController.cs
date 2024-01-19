using apiserver.DataServer;
using HelpDeskShared;
using HelpDeskShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrgsController : ControllerBase
    {
        public OrgsController()
        {

        }
        [HttpGet]
        public async Task<ActionResult<List<SDOrganization>>> GetOrgList()
        {
            try
            {
                return Ok(DataHelperHD.GetOrgsAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
