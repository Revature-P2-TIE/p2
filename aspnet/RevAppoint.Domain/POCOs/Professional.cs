namespace RevAppoint.Domain.POCOs
{
    public class Professional : User
    {
        public string Title { get; set; }
        public Time AvailableTime { get; set; }

        public Professional(){}

        public Professional(string title, Time availableTime)
        {
            this.Title = title;
            this.AvailableTime = availableTime;
        }
    }
}