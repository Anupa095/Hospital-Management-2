using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private const string SessionKeyUser = "_User";

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Hardcoded check
        if (username == "admin" && password == "123")
        {
            HttpContext.Session.SetString(SessionKeyUser, username);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid username or password";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove(SessionKeyUser);
        return RedirectToAction("Login");
    }
}
