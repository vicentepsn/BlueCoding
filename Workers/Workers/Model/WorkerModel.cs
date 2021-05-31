using System;
using System.Collections.Generic;
using System.Text;

namespace Workers.Model
{
    public class WorkerModel : BaseNotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetField(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetField(ref _lastName, value); }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set 
            { 
                SetField(ref _birthDate, value);
                RaisePropertyChanged(nameof(Age));
            }
        }

        public int? Age 
        {
            get
            {
                if (BirthDate == null)
                {
                    return null;
                }
                var today = DateTime.Today;
                var age = today.Year - BirthDate?.Year ?? today.Year;
                // Go back to the year in which the person was born in case of a leap year
                if (BirthDate?.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        private DateTime? _startWorkingAt;
        public DateTime? StartWorkingAt
        {
            get { return _startWorkingAt; }
            set
            {
                SetField(ref _startWorkingAt, value);
                RaisePropertyChanged(nameof(Age));
            }
        }

        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                SetField(ref _salary, value);
                RaisePropertyChanged(nameof(Age));
            }
        }

        public WorkerModel Clone()
        {
            return (WorkerModel)this.MemberwiseClone();
        }

        public void UpdateValues(WorkerModel workerModel)
        {
            Id = workerModel.Id;
            Name = workerModel.Name;
            LastName = workerModel.LastName;
            BirthDate = workerModel.BirthDate;
            StartWorkingAt = workerModel.StartWorkingAt;
            Salary = workerModel.Salary;
        }

    }
}
