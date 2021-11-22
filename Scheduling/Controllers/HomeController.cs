using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Scheduling.Models;

namespace Scheduling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext dBContext;
        private readonly SignInManager<MyUsersIdentity> _signInManager;
        private readonly UserManager<MyUsersIdentity> _userManager;
        
        public HomeController(ApplicationDBContext context, SignInManager<MyUsersIdentity> signInManager, UserManager<MyUsersIdentity> userManager)
        {
            _userManager = userManager;
            dBContext = context;
            _signInManager = signInManager;
            
        }

        //[Authorize]
        public JsonResult GetData()
        {
            
            var result = dBContext.Reservations.ToList().Where(u => u.User == _userManager.GetUserAsync(User).Result);
            if(result == null)
            {
                return Json("");
            }
            
            return Json(result);


        }

        public async Task<JsonResult> GetSlots(string specialist, string date)
        {
            //var reservations = dBContext.Reservations.ToList();
            // работает 
            var reservations = await dBContext.Reservations.Where(d => d.Date == date && d.Specialist == specialist).Select(t => t.Time).ToListAsync();

            //var reservations = await dBContext.Reservations.Where(d => d.Date == dateTime).Where(s => s.Specialist == specialist).Select(t => t.Time).ToListAsync();
            var result = WorkingHours.GetHours().Except(reservations);

            if (result == null)
           {
               return Json("No free time slots");
          }
            return Json(result);
        }
        
  
        public async Task<IActionResult> TimeSlot(string specialist)
        {
            var reservations = await dBContext.Reservations.Where(s => s.Specialist == specialist).Select(t => t.Time).ToListAsync();
            //ViewBag.Hours = WorkingHours.GetHours().Except(reservations);
            ViewBag.Hours = reservations;
            ViewBag.Specializations = dBContext.Users.Where(s => s.Specialization != null).Select(u => u.Specialization + " ( " + u.Name + " " + u.Surname + " )");
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult UsersProfile() 
        {
            var user = _userManager.GetUserAsync(User).Result;

            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> UsersProfile(MyUsersIdentity myUser)
        {
            dBContext.Users.Update(myUser);
            await dBContext.SaveChangesAsync();
            return View();
        }
   
       // [Authorize]
        public IActionResult Index()
        {
            ViewBag.Hours = WorkingHours.GetHours();
            ViewBag.Specializations = dBContext.Users.Where(s => s.Specialization != null).Select(u => u.Specialization + " ( " + u.Name + " " + u.Surname + " )");
            return View();
        }
       

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterModel register)
        {
            var hasher = new PasswordHasher<MyUsersIdentity>();         
            var random = new Random();
            Guid g = Guid.NewGuid();

             if (ModelState.IsValid)
              {
           
                MyUsersIdentity usersIdentity = new MyUsersIdentity
                {
                   UserName = register.Name+"" + register.Surname + random.Next(1000), 
                    Name = register.Name,
                    Surname = register.Surname,
                    TelNumber = register.TelNumber,
                    Email = register.Email,
                    Gender = register.Gender,
                    PasswordHash = hasher.HashPassword(null, register.Password),
                    SecurityStamp = string.Empty,
                    Id = g.ToString(),                   
                    DateOfBirth = register.DateOfBirth
               
                };
           

            var result = await _userManager.CreateAsync(usersIdentity, register.Password);
              if (result.Succeeded)
              {
                await dBContext.SaveChangesAsync();
                await _signInManager.SignInAsync(usersIdentity, false);

                  return RedirectToAction("Login", "Home");
              }
              else
              {
                  foreach (var error in result.Errors)
                  {
                      ModelState.AddModelError(string.Empty, error.Description);
                  }
                   
              }

            }

           return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel login = new LoginViewModel();
            var user = _userManager.FindByEmailAsync(login.Email);
            ViewBag.User = user;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            if (_userManager.GetRolesAsync(user).Result.FirstOrDefault() == "Doctor")
                            {
                                return RedirectToAction("DayWorkingList", "Doctors");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }

                    ViewBag.Result = "Error";
                    ModelState.AddModelError("", "User was not found. Chek your email or password!");
                    return View();


                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return View();
        }
       // [Authorize]
        [HttpGet]
        public IActionResult Reservation()
        {
            ViewBag.Hours = WorkingHours.GetHours();
           
            return View();
            
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Reservation(ReservationModel model)
        {
                    ViewBag.Error = "";
                    var user = _userManager.Users.FirstOrDefault();
                    var doctor = dBContext.Users.Where(u => (u.Specialization + " ( " + u.Name + " " + u.Surname + " )") == model.Specialist).Select(user => user).FirstOrDefault();
                    
                    ReservationModel reservation = new ReservationModel
                    {
                        Id = model.Id,
                        Date = model.Date,
                        Time = model.Time,
                        Specialist = model.Specialist,
                        SpecialistName = doctor,
                        User = user, 
                        UserNameSurname = user.Name + " " + user.Surname
                    };

                    // int compareDates = DateTime.Compare(DateTime.Today, reservation.Date);
                    //  if(compareDates > 0)
                    //{
                    //return RedirectToAction("Error");
                    //return new JavaScriptResult("<script language='javascript' type='text/javascript'>$(function () { alert('Some error occured!')});</script>");
                    //return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>");
                    //return new JavaScriptResult("swal({text: 'Make sure that dates are correct!',icon: 'error',}); ");
                    //return Json(new { message = "Some error occured!", succes = true});
                    //return new JavaScriptResult("alert('Some error')");
                    //     return new JavaScriptResult("<script language='javascript' type='text/javascript'>$(function(){Swal.fire({title: 'Delete this reservation?',text: 'You won't be able to revert this!',icon: 'question',showCancelButton: true,showConfirmButton: true,}))</script>");
                    //  }
                    //  else
                    //   {
                    await dBContext.Reservations.AddAsync(reservation);
                    dBContext.SaveChanges();
                    //return Json(new { success = true, message = "Saved successfully" });
                    return RedirectToAction("TimeSlot");
               
                // }

                //return Json(new {success = true, message = "Added!"});
                //return new JavaScriptResult("swal({text: 'Make sure that dates are correct!',icon: 'error',}); ");
            
            //return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = dBContext.Reservations.Where(i => i.Id == id).FirstOrDefault();
            dBContext.Reservations.Remove(reservation);
            await dBContext.SaveChangesAsync();
            return Json(new { success = true, message = "Deleted successfully" });
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
