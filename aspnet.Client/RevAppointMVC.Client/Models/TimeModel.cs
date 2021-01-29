using System;

namespace RevAppoint.Client.Models
{
    public class TimeModel : EntityModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}