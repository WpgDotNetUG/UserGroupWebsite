using System.Collections.Generic;

namespace DotNetUserGroup.Website.Models
{
    public interface IRepository<out T>
    {
        IEnumerable<T> All();
    }
}