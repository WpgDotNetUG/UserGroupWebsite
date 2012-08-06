using System.Web.Routing;
using RestfulRouting;
using DotNetUserGroup.Website.Controllers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DotNetUserGroup.Website.Routes), "Start")]

namespace DotNetUserGroup.Website
{
    public class Routes : RouteSet
    {
        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");

            map.Root<HomeController>(x => x.Index());

            map.Resources<PageNewsController>(x => x.Only("Index"));

        }

        public static void Start()
        {
            var routes = RouteTable.Routes;
            routes.MapRoutes<Routes>();
        }
    }
}