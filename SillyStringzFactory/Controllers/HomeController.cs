using SillyStringzFactory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace SillyStringzFactory.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Eng = _db.Engineers.ToList();
      ViewBag.Mac = _db.Machines.ToList();
      return View();
    }
    private readonly SillyStringzFactoryContext _db;
    public HomeController(SillyStringzFactoryContext db)
    {
      _db = db;
    }
  }
}