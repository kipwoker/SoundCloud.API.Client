
##SoundCloud.API.Client

# About
.NET API implementation  https://developers.soundcloud.com/docs/api/reference

# Warning
If you will run tests frequent from one account, soundcloud may ban it.

# HowTo 
Direct connection via username and password. Good for debugging and tests.
```c#
ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();
soundCloudClient = soundCloudConnector.DirectConnect("clientId", "clientSecret", "username", "password");
var user = soundCloudClient.User("42").GetUser();
Console.WriteLine(user.Id); //42
```

OAuth connection.

First of all go to your app page and fill field 'Redirect URI for Authentication' with your redirect_uri.

In my example I used this value: http://localhost:50086/Home/GetCode

You can find this sample here: .\SoundCloud.API.Client\SoundCloud.API.Client.Web\Controllers\HomeController.cs
```c#
public class HomeController : Controller
{
	private readonly ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();

	//put your app credentials here
	private const string clientId = "";
	private const string clientSecret = "";

	//specify redirect_uri
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

		//connect with code
		var soundCloudClient = soundCloudConnector.Connect(clientId, clientSecret, code, redirectUri);
		
		var accessToken = soundCloudClient.CurrentToken;
		
		//you also can connect next time with token
		soundCloudClient = soundCloudConnector.Connect(accessToken);

		var user = soundCloudClient.Me.GetUser();

		return Content(string.Format("Your full name is {0}. Current token: {1}", user.FullName, accessToken.AccessToken));
	}
}
```
If your token expires you can use soundCloudConnector.RefreshToken.

#Interface
All methods contains in SoundCloudClient:
```c#
public interface ISoundCloudClient
{
	SCAccessToken CurrentToken { get; }

	IUserApi User(string userId);
	IUsersApi Users { get; }
	
	ITrackApi Track(string trackId);
	ITracksApi Tracks { get; }

	IPlaylistApi Playlist(string playlistId);

	IGroupApi Group(string groupId);
	IGroupsApi Groups { get; }

	IMeApi Me { get; }

	ICommentApi Comment(string commentId);

	IAppApi App(string appId);

	IResolveApi Resolve { get; }

	IOEmbed OEmbed { get; }
}
```

Let's have a look to IGroupApi for example. You must specify context by Id
```c#
public interface IGroupApi
{
	SCGroup GetGroup();
	
	SCUser[] GetModerators(int offset = 0, int limit = 50);
	SCUser[] GetMembers(int offset = 0, int limit = 50);
	SCUser[] GetContributors(int offset = 0, int limit = 50);
	SCUser[] GetUsers(int offset = 0, int limit = 50);
	
	SCTrack[] GetApprovedTracks(int offset = 0, int limit = 50);
	SCTrack[] GetPendingTracks(int offset = 0, int limit = 50);
	SCTrack GetPendingTrack(string trackId);
	void AcceptPendingTrack(string trackId);
	void RejectPendingTrack(string trackId);

	SCTrack[] GetContributions(int offset = 0, int limit = 50);
	SCTrack GetContribution(string trackId);
	void CreateContribution(string trackId);
	void DeleteContribution(string trackId);
}
```
Simple usage:
```c#
var soundCloudClient = soundCloudConnector.Connect(accessToken);
var moderators = soundCloudClient.Group("42").GetModerators();
```
Also you can find some useful things like a fluent query executor:
```c#
var embed = soundCloudClient.OEmbed
							.BeginQuery(url)
							.SetAutoPlay(true)
							.SetCallback("dropTable()")
							.SetColor("c6c6c6")
							.SetIFrame(false)
							.SetMaxHeight(95)
							.SetMaxWidth(42)
							.SetShowComments(false)
							.ExecuteJson();
```

#Tests
If you want run tests, you should fill settigs.json first.

Full path: .\SoundCloud.API.Client\SoundCloud.API.Client.Test\settings.json
```
{
	"ClientId" : "",
	"ClientSecret" : "",
	"UserName" : "",
	"Password" : "",
	"TestAppId" : ""
}
```
You can also specify here optional fields: TestGroupId, TestTrackId, TestUserId

#What's next
It's almost stable right now. You can check out tests with your credentials.

I want to add this library to nuget and implement in web-project api console like this: https://developers.soundcloud.com/console

But better. :)
