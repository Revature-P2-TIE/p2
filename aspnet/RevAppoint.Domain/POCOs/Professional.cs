namespace RevAppoint.Domain.POCOs
{
    public class Professional : User
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public Time AvailableTime { get; set; }
        public int AppointmentLengthInHours {get;set;}
        //hourlyrate

        public Professional(){this.Type = this.GetType().Name;}
        public Professional(string title, string location)
        {
            this.Title = title;
            this.Location = location;
            this.AppointmentLengthInHours = 1;
            this.Type = this.GetType().Name;
        }
        public Professional(string title, string location, Time availableTime)
        {
            this.Title = title;
            this.Location = location;
            this.AvailableTime = availableTime;
            this.AppointmentLengthInHours = 1;
            this.Type = this.GetType().Name;
        }
    }
}