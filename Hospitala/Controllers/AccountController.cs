using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private const string SessionKeyUser = "_User";

    [HttpGet]
    public IActionResult Login()
    {
        // Already logged in? Go to Products
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUser)))
        {
            return RedirectToAction("Index", "Products");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "123")
        {
            HttpContext.Session.SetString(SessionKeyUser, username);
            return RedirectToAction("Index", "Products"); // ✅ Redirect to Products
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
