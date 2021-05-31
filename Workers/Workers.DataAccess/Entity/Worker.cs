using System;

namespace Workers.DataAccess.Entity
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartWorkingAt { get; set; }
        public double Salary { get; set; }

        public Worker Clone()
        {
            return (Worker)this.MemberwiseClone();
        }
    }
}
