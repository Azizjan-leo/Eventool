using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventool.Models
{
    public class Reservation
    {
        public string VisitorId { get; set; }
        public int EventEntityId { get; set; }

        public virtual IdentityUser Visitor { get; set; }
        public virtual EventEntity EventEntity { get; set; }
    }
}
