using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Domain.Entities;
using Template.Domain.UseCases;

namespace Template.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Roll(Guid id)
        {
            RollManagement rollManagement = new RollManagement();
            var roll = rollManagement.get(id);
            if (roll == null)
            {
                return new HttpNotFoundResult();
            }
            return View(roll);
        }

        public ActionResult New(int low, int high)
        {
            Guid id = Guid.NewGuid();
            Roll roll = new Roll();
            roll.Id = id;
            roll.RollRangeBoundaryBottom = low;
            roll.RollRangeBoundaryTop = high;
            RollManagement rollManagement = new RollManagement();
            rollManagement.add(roll);
            return Redirect("~/Home/Roll/" + id.ToString());
        }
        public ActionResult RollMore(Guid id)
        {
            RollManagement rollManagement = new RollManagement();
            var roll = rollManagement.get(id);
            if (roll == null)
            {
                return new HttpNotFoundResult();
            }
            int newResult = new Random().Next(roll.RollRangeBoundaryBottom, roll.RollRangeBoundaryTop + 1);
            roll.Result.Add(newResult);
            return Redirect("~/Home/Roll/" + id.ToString());
        }
    }
}