using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IStores _service;
        public MobileController(IStores manage)
        {
            _service = manage;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody] Store model)
        {
            try
            {
                var res = _service.Post(model);
                if(res)
                return Ok(new { massage = "Create record successfully!!" });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Edit([FromBody] Store model)
        {
            try
            {
                var res = _service.Edit(model);
                if (res)
                    return Ok(new { massage = "Updated record successfully!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }
       
        [HttpPost]
        [Route("getsales")]
        public async Task<IActionResult> GetSales(Sales sales)
        {
            try
            {
                var data = _service.GetSales(sales);
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Not found");
        }

        [HttpPost]
        [Route("getbrandsales")]
        public async Task<IActionResult> GetBrandsales(FillterBrand br)
        {
            try
            {
                var data = _service.GetBrandsales(br);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Not found");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = _service.Delete(id);
                if(res)
                return Ok(new { massage = "Updated record successfully!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getprofitloss")]
        public async Task<IActionResult> ProfitLoss()
        {
            try
            {
                var data = _service.ProfitLoss();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest();
        }
    }
}
