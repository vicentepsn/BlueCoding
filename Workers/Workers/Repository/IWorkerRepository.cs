using System;
using System.Collections.Generic;
using System.Text;
using Workers.Entity;

namespace Workers.Repository
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorker(int Id);
        void AddWorker(Worker worker);
        void UpdateWorker(Worker worker);
    }
}
