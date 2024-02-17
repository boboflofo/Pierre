using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Pierre.Controllers
{
  public class HomeController : Controller
  
  {
    private readonly PierreContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(PierreContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Treat[] tre = _db.Treats.ToArray();
      Flavor[] fla = _db.Flavors.ToArray();
      Dictionary<string,object[]> model = new Dictionary<string, object[]>();
      model.Add("treats", tre);
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser != null)
        {
          Flavor[] flavors = _db.Flavors
                      .Where(entry => entry.User.Id == currentUser.Id)
                      .ToArray();
          model.Add("flavors", flavors);
        }
      return View(model);
    }

  }
}