using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContractManager1.Models;
using System.IO;

namespace ContractManager1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractDetailsController : ControllerBase
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        private readonly contractContext _context;

        public ContractDetailsController(contractContext context)
        {
            _context = context;
        }

        // GET: api/ContractDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDetail>>> GetContractDetails()
        {
            return await _context.ContractDetails.ToListAsync();
        }

        // GET: api/ContractDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractDetail>> GetContractDetail(string id)
        {
            var contractDetail = await _context.ContractDetails.FindAsync(id);

            if (contractDetail == null)
            {
                return NotFound();
            }

            return contractDetail;
        }

        // PUT: api/ContractDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractDetail(string id, ContractDetail contractDetail)
        {
            if (id != contractDetail.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(contractDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContractDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContractDetail>> PostContractDetail(ContractDetail contractDetail)
        {
            _context.ContractDetails.Add(contractDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContractDetailExists(contractDetail.ContractId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContractDetail", new { id = contractDetail.ContractId }, contractDetail);
        }

        // DELETE: api/ContractDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractDetail(string id)
        {
            var contractDetail = await _context.ContractDetails.FindAsync(id);
            if (contractDetail == null)
            {
                return NotFound();
            }

            _context.ContractDetails.Remove(contractDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }





        //[HttpPost]
        //public async Task<IActionResult> Index(IFormFile mydoc)
        //{
        //    if (mydoc != null)
        //    {
        //        var path = Path.Combine(wwwrootDirectory, Path.GetFileNameWithoutExtension(mydoc.FileName) + Path.GetExtension(mydoc.FileName));

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await mydoc.CopyToAsync(stream);
        //        }
        //    }
        //    return View();
        //}




        private bool ContractDetailExists(string id)
        {
            return _context.ContractDetails.Any(e => e.ContractId == id);
        }
    }
}
