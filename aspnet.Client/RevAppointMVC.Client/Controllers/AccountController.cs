using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;
public class AccountController : Controller
{

    [HttpPost]
    public IActionResult SignOut()
    {
        return new SignOutResult(new[] { 
        OktaDefaults.MvcAuthenticationScheme, 
        CookieAuthenticationDefaults.AuthenticationScheme });
    }
}