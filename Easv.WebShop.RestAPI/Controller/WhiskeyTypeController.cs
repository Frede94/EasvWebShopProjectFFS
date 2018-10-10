using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.WebShop.Core.ApplicationService.IServices;
using Easv.WebShop.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easv.WebShop.RestAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhiskeyTypesController : ControllerBase
    {
        private readonly IWhiskeyTypeService _wtService;

        public WhiskeyTypesController(IWhiskeyTypeService whiskeyTypeService)
        {
            _wtService = whiskeyTypeService;
        }
        // GET: api/WhiskeyType
        [HttpGet]
        public ActionResult<IEnumerable<WhiskeyType>> Get([FromQuery] Filter filter)        
        {
            try
            {
                if (filter.CurrentPage != 0 && filter.ItemsPrPage != 0)
                {
                    return Ok(_wtService.ReadAllFiltered(filter));
                }
                else
                {
                    return Ok(_wtService.ReadAll());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/WhiskeyType/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<WhiskeyType> Get(int id)
        {
            try
            {
                return Ok(_wtService.RetrieveById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }             
        }

        // POST: api/WhiskeyType
        [HttpPost]
        public ActionResult<WhiskeyType> Post([FromBody] WhiskeyType whiskeyType)
        {
            try
            {
                return Ok(_wtService.CreateWhiskeyType(whiskeyType));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/WhiskeyType/5
        [HttpPut("{id}")]
        public ActionResult<WhiskeyType> Put(int id, [FromBody] WhiskeyType whiskeyType)
        {
            try
            {
                whiskeyType.Id = id;
                return Ok(_wtService.Update(whiskeyType));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Patch: api/whiskeyType/5
        [HttpPatch("{id}")]
        public ActionResult<WhiskeyType> Patch(int id, [FromBody]WhiskeyType whiskeyType)
        {
            try
            {
                whiskeyType.Id = id;
                return Ok(_wtService.Update(whiskeyType));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<WhiskeyType> Delete(int id)
        {
            try
            {
                return Ok(_wtService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
