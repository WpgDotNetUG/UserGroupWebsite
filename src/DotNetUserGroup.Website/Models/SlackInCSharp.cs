using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;

namespace DotNetUserGroup.Website.Models
{
	public class SlackInCSharp : ISlackInc
	{
		private readonly string _uri;
		private const string UrlFormat = "https://{0}.slack.com/api/users.admin.invite?token={1}";
		private readonly Encoding _encoding = new UTF8Encoding();

		public SlackInCSharp()
		{
			var org = ConfigurationManager.AppSettings["SlackOrg"] ?? "wpgdotnet";
			var token = ConfigurationManager.AppSettings["SlackToken"];
			_uri = string.Format(UrlFormat, org, token);
		}

		public SlackInvitationResponse Invite(string email)
		{
			using (var client = new WebClient())
			{
				var data = new NameValueCollection();
				data["email"] = email;

				var response = client.UploadValues(_uri, "POST", data);

				var responseText = _encoding.GetString(response);
				var res = System.Web.Helpers.Json.Decode(responseText);
				return new SlackInvitationResponse
				{
					Ok = res["ok"],
					ErrorMessage = res["error"]
				};
			}
		}
	}

	public class SlackInvitationResponse
	{
		public bool Ok;
		public string ErrorMessage;
	}
}