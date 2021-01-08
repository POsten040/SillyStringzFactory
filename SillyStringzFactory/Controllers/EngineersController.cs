using SillyStringzFactory.Models;
using Microsoft.AspNetCore.Mvc;


namespace SillyStringzFactory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly SillyStringzFactoryContext _db;
    public EngineersController(SillyStringzFactoryContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer Engineer)
    {
      _db.Engineers.Add(Engineer);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}