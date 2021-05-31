using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workers.DataAccess.Entity;

namespace Workers.DataAccess.Repository
{
    /// <summary>
    /// In memory Mock class for a worker repository
    /// </summary>
    public class WorkerRepository : IWorkerRepository
    {
        private readonly List<Worker> _inMemoryWorkers;
        private int _lastId;

        public WorkerRepository()
        {
            _inMemoryWorkers = new List<Worker> 
            {
                new Worker
                {
                    Id = 1,
                    Name = "Adan",
                    LastName = "Smith",
                    BirthDate = new DateTime(1980, 01, 15),
                    Salary = 4350.0,
                    StartWorkingAt = new DateTime(2020, 02, 01)
                },
                new Worker
                {
                    Id = 2,
                    Name = "Jonas",
                    LastName = "Petterson",
                    BirthDate = new DateTime(1973, 04, 28),
                    Salary = 5850.0,
                    StartWorkingAt = new DateTime(2001, 01, 05)
                },
                new Worker
                {
                    Id = 3,
                    Name = "Maria",
                    LastName = "Jonson",
                    BirthDate = new DateTime(1985, 09, 10),
                    Salary = 7100.0,
                    StartWorkingAt = new DateTime(2003, 02, 01)
                },
                new Worker
                {
                    Id = 4,
                    Name = "Peter",
                    LastName = "Bronson",
                    BirthDate = new DateTime(1957, 08, 15),
                    Salary = 4000.0,
                    StartWorkingAt = new DateTime(2019, 10, 01)
                },
            };

            _lastId = 4;
        }

        public void AddWorker(Worker worker)
        {
            _lastId++;
            worker.Id = _lastId;
            _inMemoryWorkers.Add(worker.Clone());
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _inMemoryWorkers.Select(_ => _.Clone());
        }

        public Worker GetWorker(int id)
        {
            return _inMemoryWorkers.FirstOrDefault(_ => _.Id == id).Clone();
        }

        public void UpdateWorker(Worker worker)
        {
            var storedWorker = _inMemoryWorkers.FirstOrDefault();
            if (storedWorker != null)
            {
                storedWorker.Id = worker.Id;
                storedWorker.Name = worker.Name;
                storedWorker.LastName = worker.LastName;
                storedWorker.BirthDate = worker.BirthDate;
                storedWorker.Salary = worker.Salary;
                storedWorker.StartWorkingAt = worker.StartWorkingAt;
            }
        }

        public void DeleteWorker(int id)
        {
            var index = _inMemoryWorkers.FindIndex(_ => _.Id == id);
            if (index >= 0)
            {
                _inMemoryWorkers.RemoveAt(index);
            }
        }
    }
}
