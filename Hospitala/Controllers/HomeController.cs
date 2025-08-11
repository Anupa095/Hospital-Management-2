using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private const string SessionKeyUser = "_User";

    public IActionResult Index()
    {
        var user = HttpContext.Session.GetString(SessionKeyUser);
        if (string.IsNullOrEmpty(user))
        {
            return RedirectToAction("Login", "Account");
        }
        ViewBag.User = user;
        return View();
    }
}
