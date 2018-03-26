using System.Security.Claims;

namespace GraphQLService
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
