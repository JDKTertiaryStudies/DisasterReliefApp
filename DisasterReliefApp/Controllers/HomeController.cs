using Microsoft.AspNetCore.Mvc;
using DisasterReliefApp.Models;
using DisasterReliefApp.ViewModels;
using System.Threading.Tasks;

namespace DisasterReliefApp.Controllers
{
    public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Displays the index page with incidents, donations, and volunteers.
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel
        {
            Incidents = _context.Incidents.ToList(),
            Donations = _context.Donations.Include(d => d.User).ToList(),
            Volunteers = _context.Volunteers.Include(v => v.User).Include(v => v.Project).ToList()
        };
        return View(viewModel);
    }
}

}
