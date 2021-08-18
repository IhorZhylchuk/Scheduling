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
       // private readonly AppDbContext _appDbContext;
      
       
        public HomeController(ApplicationDBContext context, SignInManager<MyUsersIdentity> signInManager, UserManager<MyUsersIdentity> userManager)
        {
            _userManager = userManager;
            dBContext = context;
            _signInManager = signInManager;
            
        }
        
        public JsonResult GetData()
        {
            var result = dBContext.Reservations.ToList();
            return Json(result);
        }

        [Authorize]
        public IActionResult Index()
        {
            
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
                                return RedirectToAction("Index", "Doctors");
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
        [HttpGet]
        public IActionResult Reservation()
        {
            ViewBag.Hours = WorkingHours.GetHours();
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> Reservation(ReservationModel model)
        {
            ViewBag.Error = "";
            if (ModelState.IsValid)
            {
                try
                {

                    ReservationModel reservation = new ReservationModel
                    {
                        Id = model.Id,
                        Date = model.Date,
                        Email = model.Email,
                        Gender = model.Gender,
                        Name = model.Name,
                        Specialist = model.Specialist,
                        Surname = model.Surname,
                        TelNumber = model.TelNumber,
                        Time = model.Time
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
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("Error",e.Message.ToString());
                }
                // }

                //return Json(new {success = true, message = "Added!"});
                //return new JavaScriptResult("swal({text: 'Make sure that dates are correct!',icon: 'error',}); ");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //var reservation = await dBContext.Reservations.Where(i => i.Id == id).FirstOrDefaultAsync();
           // dBContext.Reservations.Remove(reservation);
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
