using Microsoft.AspNetCore.Identity;

namespace Eventool.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public IdentityUser Admin { get; set; }
        public string Name { get; set; }
        public PlatformType Type { get; set; }
        public int Capacity { get; set; }
    }


    public class CreatePlatformVM
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Capacity { get; set; }
    }
}
