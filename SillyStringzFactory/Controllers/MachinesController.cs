using SillyStringzFactory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;


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
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(Machine => Machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
        .Include(Machine => Machine.JoinEntries)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(Machine => Machine.MachineId == id);
      return View(thisMachine);
    }
        public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(MachinesController => MachinesController.MachineId == id);
      ViewBag.Engineers = _db.Engineers.ToList();
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, List<int> Engineers)
    {
      if (Engineers.Count != 0)
      {
        foreach (int engineer in Engineers)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = engineer, MachineId = machine.MachineId });
        }
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = machine.MachineId});
    }
  }
}