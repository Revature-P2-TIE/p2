using System;

namespace RevAppoint.Domain.POCOs
{
    public abstract class AEntityID
    {
        public long EntityID {get;}
        
        protected AEntityID()
        {
            EntityID = DateTime.Now.Ticks;
        }
    }
}