using System;

namespace Demo.Domain
{
    public class Trip : Entity
    {
        [AfterToday]
        public DateTime Date { get; set; }
    }
}
