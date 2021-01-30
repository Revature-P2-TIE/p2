namespace RevAppoint.Domain.POCOs
{
    public class Appointment : AEntityID
    {
        public Time Time { get; set; }
        public Professional Professional { get; set; }
        public User Client { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsFufilled { get; set; }
     
     
        public Appointment(){}
        public Appointment(Time time, Professional professional, User client)
        {
            this.Time = time;
            this.Professional = professional;
            this.Client = client;
            this.IsFufilled = false;
            this.IsAccepted = false;
        }

    }
}