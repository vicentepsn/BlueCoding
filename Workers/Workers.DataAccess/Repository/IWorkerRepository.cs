using System;
using System.Collections.Generic;
using System.Text;
using Workers.DataAccess.Entity;

namespace Workers.DataAccess.Repository
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorker(int id);
        void AddWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(int id);
    }
}
