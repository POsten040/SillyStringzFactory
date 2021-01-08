using SillyStringzFactory.Models;
using Microsoft.AspNetCore.Mvc;


namespace SillyStringzFactory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly SillyStringzFactoryContext _db;
    public MachinesController(SillyStringzFactoryContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine Machine)
    {
      _db.Machines.Add(Machine);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}