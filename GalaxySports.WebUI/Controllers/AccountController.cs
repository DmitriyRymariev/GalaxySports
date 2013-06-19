using GalaxySports.Domain.Abstract;
using GalaxySports.Domain.Entities;
using GalaxySports.WebUI.Infrastructure.Abstract;
using GalaxySports.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GalaxySports.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        IUserRepository userRepository;

        public AccountController(IAuthProvider auth, IUserRepository usrRepository)
        {
            authProvider = auth;
            userRepository = usrRepository;
        }

        public ViewResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    ModelState.AddModelError("", "sdfsdf");
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Please enter login and password");
                return View();
            }
        }

        public ActionResult LogOff(string returnUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(returnUrl ?? Url.Action("List", "Product"));
        }

        public ViewResult EditUser(int userID)
        {
            GalaxySports.Domain.Entities.User user = userRepository.Users.FirstOrDefault(u => u.UserID == userID);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(GalaxySports.Domain.Entities.User user)
        {
            if (ModelState.IsValid)
            {
                bool newUser = false;
                if (user.UserID == 0)
                {
                    if (userRepository.Users.Count(x => x.Login == user.Login) > 0)
                    {
                        ModelState.AddModelError("", string.Format("User with login \"{0}\" is already exists!", user.Login));
                        return View(user);
                    }
                    else 
                    {
                        user.Role = UserRoles.User;
                        newUser = true;
                    }
                }

                userRepository.SaveUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.Name);
                if (newUser)
                {
                    return RedirectToAction("LogOn");
                }
                return RedirectToAction("List", "Product");
            }
            else
            {
                return View(user);
            }
        }

        public ViewResult SignUp()
        {
            return View("EditUser", new GalaxySports.Domain.Entities.User());
        }
    }
}
