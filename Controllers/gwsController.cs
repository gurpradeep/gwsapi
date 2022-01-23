using Microsoft.AspNetCore.Mvc;
using gwsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace gwsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class gwsController : ControllerBase
{
    private readonly gwsContext _context;
    public gwsController(gwsContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<gwsItemDTO>>> GetGWSItems()
    {
        return await _context.gwsItems
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }


   [HttpPost]
   [ProducesResponseType(201)]
    public async Task<ActionResult<gwsItem>> PostItem(gwsItem Item)
    {
            var item = new gwsItem
            {
                Country = Item.Country,
                LOB = Item.LOB,
                Premium = Item.Premium

            };

            _context.gwsItems.Add(item);
            await _context.SaveChangesAsync();
            return NoContent();
    }


    [HttpGet ("{country}/{lob}")]
    public decimal GetAverage(string country, string lob)
    {
       var avg = _context.gwsItems
            .Where(e => e.Country == country && e.LOB == lob)
            .Select(e => e.Premium)
            .DefaultIfEmpty()
            .Average();
    
        return avg;
    }

    private static gwsItemDTO ItemToDTO(gwsItem item) =>
            new gwsItemDTO
            {
                Id = item.Id,
                Country = item.Country,
                LOB = item.LOB,
                Premium = item.Premium,
                
            };


}
