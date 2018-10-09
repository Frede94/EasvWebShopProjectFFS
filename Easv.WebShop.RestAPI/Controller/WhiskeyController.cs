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
    public class WhiskeyController : ControllerBase
    {
        private readonly IWhiskeyService _whiskeyService;

        public WhiskeyController(IWhiskeyService whiskeyService)
        {
            _whiskeyService = whiskeyService;
        }
        // GET: api/Whiskey
        [HttpGet]
        public ActionResult<IEnumerable<Whiskey>> Get([FromQuery] Filter filter)
        {
            try
            {
                if(filter.CurrentPage != 0 && filter.ItemsPrPage != 0)
                {
                    return Ok(_whiskeyService.ReadAllFiltered(filter));
                }
                else
                {
                    return Ok(_whiskeyService.ReadAll());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Whiskey/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Whiskey> Get(int id)
        {
            try
            {
                return Ok(_whiskeyService.RetrieveById(id));
        
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Whiskey
        [HttpPost]
        public ActionResult<Whiskey> Post([FromBody] Whiskey whiskey)
        {
            try
            {
                return Ok(_whiskeyService.CreateWhiskey(whiskey));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Whiskey/5
        [HttpPut("{id}")]
        public ActionResult<Whiskey> Put(int id, [FromBody] Whiskey whiskey)
        {
            try
            {
                whiskey.Id = id;
                return Ok(_whiskeyService.Update(whiskey));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Whiskey> Delete(int id)
        {
            try
            {
                return _whiskeyService.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
