using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.API.Models
{
    [DebuggerDisplay("{Student_Id}-{Name}-{BirthDate}-{Is_Active}")]
    public class Student
    {
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Is_Active { get; set; }
        public int BornDaysAfterJan12000 { get; set; }
    }
}
