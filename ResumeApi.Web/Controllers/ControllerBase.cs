namespace ResumeApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResumeApi.Model;    

    public class ControllerBase : Controller
    {
        protected virtual IActionResult SomeOrNotFound<T>(Maybe<T> someOrNone) =>
            someOrNone.Match(some => (IActionResult)Ok(some), () => NotFound());        
    }
}
