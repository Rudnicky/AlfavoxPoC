using Microsoft.AspNetCore.Identity;

namespace AlfavoxPoC.Core.Domain
{
    public abstract class EntityBase : IdentityRole
    {
        public int Id { get; set; }
    }
}
