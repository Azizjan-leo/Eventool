using System;

namespace Eventool.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Platform Platform { get; set; }
        public Organization Organization { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
