using SillyStringzFactory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineer => Engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
        .Include(Engineer => Engineer.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(Engineer => Engineer.EngineerId == id);
      return View(thisEngineer);
    }
        public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(EngineersController => EngineersController.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, List<int> Machines)
    {
      if (Machines.Count != 0)
      {
        foreach (int machine in Machines)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machine, EngineerId = engineer.EngineerId });
        }
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}