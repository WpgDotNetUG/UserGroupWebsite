using System.Web.Mvc;

namespace DotNetUserGroup.Website.Controllers
{
    public class HomeController : Controller
    {
		private readonly ISlackInc _slackInc;

		public HomeController(ISlackInc slackInC)
	    {
			_slackInc = slackInC;
	    }
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Signup(string email)
		{
			var res = _slackInc.Invite(email);
			if (res.Ok)
			{
				ViewBag.Success = "Invitation sent!";
			}
			else
			{
				ViewBag.Error = res.ErrorMessage;
			}
			return View("Index");
		}
	}
}
