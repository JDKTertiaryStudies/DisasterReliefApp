using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ReliefManagementApp.Data;
using ReliefManagementApp.Models;

namespace ReliefManagementApp.Controllers
{
    public class ReliefProjectsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public ReliefProjectsController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ReliefProjects
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if the user has an Admin role
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            // If the user is an Admin, show all projects; otherwise, show only their projects
            var projects = isAdmin
                ? _context.ReliefProjects
                : _context.ReliefProjects.Where(p => p.UserID == currentUser.UserID);

            return View(await projects.ToListAsync());
        }

        // GET: ReliefProjects/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            var reliefProject = await _context.ReliefProjects
                .FirstOrDefaultAsync(m => m.ProjectID == id && (isAdmin || m.UserID == currentUser.UserID));

            if (reliefProject == null)
            {
                return NotFound();
            }

            return View(reliefProject);
        }

        // GET: ReliefProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReliefProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,ProjectName,Location,StartDate,EndDate,Status")] ReliefProject reliefProject)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                // Associate the created project with the current user
                reliefProject.UserID = currentUser.UserID;
                _context.Add(reliefProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reliefProject);
        }

        // GET: ReliefProjects/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            var reliefProject = await _context.ReliefProjects
                .Where(p => p.ProjectID == id && (isAdmin || p.UserID == currentUser.UserID))
                .FirstOrDefaultAsync();

            if (reliefProject == null)
            {
                return NotFound();
            }

            return View(reliefProject);
        }

        // POST: ReliefProjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProjectID,ProjectName,Location,StartDate,EndDate,Status")] ReliefProject reliefProject)
        {
            if (id != reliefProject.ProjectID)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            // Check if the user is allowed to edit this project
            if (!isAdmin && reliefProject.UserID != currentUser.UserID)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reliefProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReliefProjectExists(reliefProject.ProjectID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reliefProject);
        }

        // GET: ReliefProjects/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            var reliefProject = await _context.ReliefProjects
                .Where(p => p.ProjectID == id && (isAdmin || p.UserID == currentUser.UserID))
                .FirstOrDefaultAsync();

            if (reliefProject == null)
            {
                return NotFound();
            }

            return View(reliefProject);
        }

        // POST: ReliefProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");

            var reliefProject = await _context.ReliefProjects
                .Where(p => p.ProjectID == id && (isAdmin || p.UserID == currentUser.UserID))
                .FirstOrDefaultAsync();

            if (reliefProject == null)
            {
                return NotFound();
            }

            _context.ReliefProjects.Remove(reliefProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReliefProjectExists(string id)
        {
            return _context.ReliefProjects.Any(e => e.ProjectID == id);
        }
    }
}
