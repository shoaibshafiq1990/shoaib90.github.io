using HelpDeskShared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Eventing.Reader;

namespace apiserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    { 
        public UserController()
        {
        
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            try
            {
                return Ok(DataHelper.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] 
        public async Task<ActionResult> InsertUser(User user)
        {
            try
            {
                string res = DataHelper.InsertUser(user);
                if (res == "ok")
                    return Ok("User inserted successfully.");
                else
                    return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            try
            {
                string res = DataHelper.UpdateUser(user);
                if (res == "ok")
                    return Ok("User Updated successfully.");
                else
                    return BadRequest(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
