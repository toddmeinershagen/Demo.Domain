using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    public class Trip : DomainObject
    {
        [AfterToday]
        public DateTime Date { get; set; }
    }
}
