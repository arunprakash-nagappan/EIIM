using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using travel.Models;

namespace travel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    
    [HttpGet]
public IActionResult Booking()
    {
        return View();
    }
    [HttpPost]
 public IActionResult Booking(Booking book)
    {
        Repository.Booking(book);
        return View("Opening");
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SignUp(Signup user)
    {
        Repository.Signup(user);
        return View("SignUpSuccess");
    }
     [HttpGet]
    public IActionResult Opening()
    {
        return View();
    }

    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
   public IActionResult Login(Login enteredUser)
    {
        string valid_user=enteredUser.Username;
        if (Repository.IsUserValid(enteredUser))
        {
            HttpContext.Session.SetString("UserName", valid_user);
            return View("Opening");
        }
        else
        {
            ViewBag.message="Invalid Credentialds";
            return View(); // Return to the login view with an error message
        }
    }
    // public IActionResult Booking(Booking Book)
    // {
    //     if (Repository.Booking(Book))
    //     {
    //         // return View("Booking");
    //     }
    //     else
    //     {
    //         ModelState.AddModelError(string.Empty, "Invalid username or password");
    //         return View(); // Return to the login view with an error message
    //     }
    // }
    [HttpGet]
    public IActionResult Ticket()
    {
        string username = HttpContext.Session.GetString("UserName");
        var Tickets = Repository.GetUserTickets(username);
        return View(Tickets);
    }
    [HttpGet]
     public IActionResult CancelTicket(CancelTicket cancelticket)
    {
        Repository.CancelTicket(cancelticket);
        return View("CancelTicket");
    }
    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login","Home");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
