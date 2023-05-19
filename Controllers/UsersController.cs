using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Geinie9.Models;
using Web_Geinie9.Models.Repository;

namespace Web_Geinie9.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
       
        private readonly SignUp _signUp;
        private readonly LogIn _signIn;
        public UsersController(SignUp signUp, LogIn signIn)
        {
            _signUp = signUp;
            _signIn = signIn;
        }

        #region SignUp
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("Create")]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _signUp.AddUser(user);

            }
            return View(user);

            
            
        }

        #endregion


        #region SignIn
        [HttpGet("SignIn")]
        [Route("/SignIn")]
        public IActionResult SignIn()
        {
            return View();

        }

        [HttpPost("SignIn")]
        public IActionResult SignIn(string email , string pass)
        {
            User user; 
           if(ModelState.IsValid)
            {
                user = _signIn.SignIn(email, pass);
                if(user != null )
                {
                    return RedirectToAction(nameof(HelloPage));
                }
                return View(user);
            }
            return View();
        }
        #endregion

        [HttpGet("HelloPage")]
        public IActionResult HelloPage()
        {
            return View();
        }

    }
}
