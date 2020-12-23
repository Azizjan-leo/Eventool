using Microsoft.AspNetCore.Identity;

namespace Eventool.Models
{
    public class CreateOrganizationVM
    {
        public int Type { get; set; }
        public string Name { get; set; }
    }
    public class Organization
    {
        public int Id { get; set; }
        public OrganizationType Type { get; set; }
        public string Name { get; set; }
        public IdentityUser Admin { get; set; }
    }
}
