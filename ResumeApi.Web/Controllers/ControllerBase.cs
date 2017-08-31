namespace ResumeApi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResumeApi.Common;

    public class ControllerBase : Controller
    {
        protected virtual IActionResult SomeOrNotFound<T>(Maybe<T> someOrNone) =>
            someOrNone.Map(some => (IActionResult)Ok(some), () => NotFound());        
    }
}
