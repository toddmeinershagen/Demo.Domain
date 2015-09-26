using System;

namespace Demo.Domain
{
    public class Trip : DomainObject
    {
        [AfterToday]
        public DateTime Date { get; set; }
    }
}
