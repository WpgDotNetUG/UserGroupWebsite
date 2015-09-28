using DotNetUserGroup.Website.Models;

public interface ISlackInc
{
	SlackInvitationResponse Invite(string email);
}
