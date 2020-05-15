using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using HeardInventory.Models;

namespace HeardInventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private readonly HeardInventoryContext _db;

    public ItemsController(HeardInventoryContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get(string name, string category, string vendor)
    {
      var query = _db.Items.AsQueryable();

      if(name != null)
      {
        query = query.Where(item => item.ItemName == name);
      }
      if(category != null)
      {
        query = query.Where(item => item.Category.CategoryName == category);
      }
      if(vendor != null)
      {
        query = query.Where(item => item.Vendor.VendorName == vendor);
      }
      return query.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
      return _db.Items.FirstOrDefault(item => item.ItemId == id);
    }

    [EnableCors("MyPolicy")]
    [HttpPost]
    public void Post([FromBody] Item item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
    }

    [HttpPut]
    public void Put(int id, [FromBody] Item item)
    {
      item.ItemId = id;
      _db.Entry(item).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Item itemForDeletion = _db.Items.FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(itemForDeletion);
      _db.SaveChanges();
    }
  }
}