using System;
using System.Collections.Generic;
using System.Text;

namespace Workers.Model
{
    public class WorkerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LaseName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get { throw new NotImplementedException(); } }
        public DateTime StartWorkingAt { get; set; }
        public double Salary { get; set; }
    }
}
