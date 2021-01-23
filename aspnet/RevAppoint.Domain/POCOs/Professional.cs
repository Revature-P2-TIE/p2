namespace RevAppoint.Domain.POCOs
{
    public class Professional : User
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public Time AvailableTime { get; set; }

        public Professional(){}
        public Professional(string title, string location)
        {
            this.Title = title;
            this.Location = location;
        }
        public Professional(string title, string location, Time availableTime)
        {
            this.Title = title;
            this.Location = location;
            this.AvailableTime = availableTime;
        }
    }
}