using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Pierre.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private readonly PierreContext _db;

    public HomeController(PierreContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Treat[] tre = _db.Treats.ToArray();
      Flavor[] fla = _db.Flavors.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      model.Add("treats", tre);
      model.Add("flavors", fla);
      return View(model);
    }

  }
}