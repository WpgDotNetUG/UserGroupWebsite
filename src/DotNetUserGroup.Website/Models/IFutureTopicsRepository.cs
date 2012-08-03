using System.Collections.Generic;

namespace DotNetUserGroup.Website.Models
{
    public interface IFutureTopicsRepository
    {
        IEnumerable<FutureTopicInfo> All();
    }
}