using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject3.Data;
using WebAppProject3.Models;

// authorization imports
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace WebAppProject3.Controllers
{
    public class UserController : Controller
    {
        // will use Entity Framework to access database
        private ApplicationDbContext _context;

        // constructor for UserController
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // register controller with Entity Framework
        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {

            // initialize new user model, we will need it in order to build the form
            // in the view
            UserModel user = new UserModel();

            // enable User.Identity.IsAuthenticated
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            return View(user);
        }

        

        // register submit controller with Entity Framework
        [HttpPost]
        [Route("/register")]
        public IActionResult RegisterSubmit(UserModel user)
        {
            // check if model is valid
            if (ModelState.IsValid)
            {
                // check if username is already taken
                if (_context.Users.Any(u => u.Username == user.Username))
                {
                    // if username is taken, add error to model state
                    ModelState.AddModelError("Username", "Username is already taken");
                    // return view with model state
                    return View("Register",user);
                }

                // check if password and password confirmation match using method from UserModel
                if (user.ComparePasswordConfirmation() == false)
                {
                    // if passwords do not match, add error to model state
                    ModelState.AddModelError("Password", "Password and password confirmation do not match");
                    // return view with model state
                    return View("Register", user);
                }

                // validate password using method from UserModel
                if (!user.ValidatePassword(user.Password))
                {
                    // if password is not valid, add error to model state
                    ModelState.AddModelError("Password", "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character");
                    // return view with model state
                    return View("Register", user);
                }

                Console.WriteLine("Password is valid");

                // hash and salt password
                user.HashAndSaltPassword(user.Password);

                // delete password and password confirmation from model state
                user.DeletePlainPasswordFields();

                // add user to database
                _context.Users.Add(user);
                _context.SaveChangesAsync();

                // redirect to login page
                return RedirectToAction("Login", "User");
            } 
            
            // if model is not valid, return view with model state
            return View("Register", user);
        }

        // login get controller
        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            // initialize new user model, we will need it in order to build the form
            // in the view
            UserModel user = new UserModel();
            return View(user);
        }

        // login post controller
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("/login")]
        public async Task<IActionResult> LoginSubmitAsync(UserModel user)
        {
            // check if model is valid
            if (ModelState.IsValid)
            {
                // check if username exists in database
                if (_context.Users.Any(u => u.Username == user.Username))
                {
                    // get user from database
                    UserModel dbUser = _context.Users.Where(u => u.Username == user.Username).First();

                    // check if password matches
                    if (dbUser.ComparePasswordFromDB(user.Password))
                    {
                        // if password matches, add user to session

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            // Add other claims as needed
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        // redirect to home page

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // if password does not match, add error to model state
                        ModelState.AddModelError("Username", "Username or password is incorrect");
                        // return view with model state
                        return View("Login", user);
                    }
                }
                else
                {
                    // if username does not exist, add error to model state
                    ModelState.AddModelError("Username", "Username or password is incorrect");
                    // return view with model state
                    return View("Login", user);
                }
            }

            // if model is not valid, return view with model state
            return View("Login", user);
        }

        // logout controller
        [HttpPost]
        [Route("/logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the home page or another page after logout
            return RedirectToAction("Index", "Home");
        }


        // a simple access denied action
        [HttpGet]
        [Route("/access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }


    
}
