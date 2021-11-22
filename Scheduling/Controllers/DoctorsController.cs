using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduling.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDBContext dBContext;
        private readonly SignInManager<MyUsersIdentity> _signInManager;
        private readonly UserManager<MyUsersIdentity> _userManager;

        public DoctorsController(ApplicationDBContext context, SignInManager<MyUsersIdentity> signInManager, UserManager<MyUsersIdentity> userManager)
        {
            _userManager = userManager;
            dBContext = context;
            _signInManager = signInManager;

        }

        [Authorize]
        public JsonResult GetData()
        {

            var result = dBContext.Reservations.ToList().Where(u => u.SpecialistName == _userManager.GetUserAsync(User).Result);
            if (result == null)
            {
                return Json("");
            }
            return Json(result);
        }
        public IActionResult DayWorkingList()
        {
            return View();
        }
    }
}
