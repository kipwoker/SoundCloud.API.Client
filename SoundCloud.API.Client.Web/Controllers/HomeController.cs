using System.Web.Mvc;
using SoundCloud.API.Client.Objects.Auth;

namespace SoundCloud.API.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();

        private const string clientId = "";
        private const string clientSecret = "";

        private const string redirectUri = "http://localhost:50086/Home/GetCode";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestCode()
        {
            var requestTokenUri = soundCloudConnector.GetRequestTokenUri(clientId, redirectUri, SCResponseType.Code, SCScope.NonExpiring, SCDisplay.Popup, null);
            return Redirect(requestTokenUri.ToString());
        }

        public ActionResult GetCode(string error, [Bind(Prefix = "error_description")] string errorDescription, string code)
        {
            if (!string.IsNullOrEmpty(error))
            {
                return Content(string.Format("Error: {0}", errorDescription));
            }

            var soundCloudClient = soundCloudConnector.Connect(clientId, clientSecret, code, redirectUri);
            
            var accessToken = soundCloudClient.CurrentToken;
            soundCloudClient = soundCloudConnector.Connect(accessToken);

            var user = soundCloudClient.Me.GetUser();

            return Content(string.Format("Your full name is {0}. Current token: {1}", user.FullName, accessToken.AccessToken));
        }
    }
}