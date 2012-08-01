using DotNetUserGroup.Website.Models;
using MavenThought.Commons.Testing;

namespace DotNetUserGroup.Website.Tests.Models
{
    /// <summary>
    /// Base specification for EventBriteRepository
    /// </summary>
    public abstract class EventBriteRepositorySpecification
        : AutoMockSpecification<EventBriteRepository, IEventRepository>
    {
         
    }
}