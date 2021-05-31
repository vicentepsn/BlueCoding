using System;
using System.Collections.Generic;
using System.Text;
using Workers.DataAccess.Entity;

namespace Workers.Service
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorkerById(int id);
        void AddWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(int id);
    }
}
