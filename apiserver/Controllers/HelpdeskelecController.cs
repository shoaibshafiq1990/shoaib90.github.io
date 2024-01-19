using apiserver.DataServer;
using HelpDeskShared;
using HelpDeskShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HelpdeskelecController : ControllerBase
    {
        public HelpdeskelecController()
        {

        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDefinition>>> GetCategoryList()
        {
            try
            {
                return Ok(DataHelperHD.GetCategoryAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDefinition>>> GetSubCategoryList()
        {
            try
            {
                return Ok(DataHelperHD.GetSubCategoryAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDefinition>>> GetSubCategoryListId(int? id = null)
        { 
            try
            {
                if (id.HasValue)
                {
                    // If 'id' is provided, retrieve a specific subcategory by ID
                    var subcategory = DataHelperHD.GetSubCategoryById(id.Value);
                    if (subcategory == null)
                    {
                        return NotFound($"Subcategory with ID {id} not found.");
                    }
                    return Ok(subcategory);
                }
                else
                {
                    // If 'id' is not provided, retrieve the list of all subcategories
                    //return Ok(DataHelperHD.GetSubCategoryAll());
                    return NotFound($"Please Specify a Paramter ID Value, Parameter Value is null.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentDefinition>>> GetdepartmentList()
        {
            try
            {
                return Ok(DataHelperHD.GetDepartmentAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<PriorityDefinition>>> GetPriorityList()
        {
            try
            {
                return Ok(DataHelperHD.GetPriorityAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<QueueDefinition>>> GetCiListId(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    // If 'id' is provided, retrieve a specific subcategory by ID
                    var ci = DataHelperHD.GetCiById(id.Value);
                    if (ci == null)
                    {
                        return NotFound($"CI list with ID {id} not found.");
                    }
                    return Ok(ci);
                }
                else
                {
                    // If 'id' is not provided, retrieve the list of all subcategories
                    //return Ok(DataHelperHD.GetSubCategoryAll());
                    return NotFound($"Please Specify a Paramter ID Value, Parameter Value is null.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TechnicianUsers>>> GetTechUserListId(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    // If 'id' is provided, retrieve a specific subcategory by ID
                    var techUser = DataHelperHD.GetTechUserById(id.Value);
                    if (techUser == null)
                    {
                        return NotFound($"CI list with ID {id} not found.");
                    }
                    return Ok(techUser);
                }
                else
                {
                    // If 'id' is not provided, retrieve the list of all subcategories
                    //return Ok(DataHelperHD.GetSubCategoryAll());
                    return NotFound($"Please Specify a Paramter ID Value, Parameter Value is null.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertServiceR(InsertServiceRequest sr)
        {
            try
            {
                string res = DataHelperHD.InsertServiceReq(sr);
                if (res == "ok")
                    return Ok("Work Order inserted successfully. "+ sr.WORKORDERID);
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
