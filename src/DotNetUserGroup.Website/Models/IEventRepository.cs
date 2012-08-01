using System.Collections.Generic;

namespace DotNetUserGroup.Website.Models
{
    public interface IEventRepository
    {
        IEnumerable<UserGroupEvent> All();
    }
}