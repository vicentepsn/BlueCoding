using System;
using System.Collections.Generic;
using System.Text;
using Workers.Entity;

namespace Workers.Service
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetWorker();
        void AddWorker(Worker worker);
        void UpdateWorker(Worker worker);
    }
}
