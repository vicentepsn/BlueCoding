using System;
using System.Collections.Generic;
using System.Text;
using Workers.Entity;

namespace Workers.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        List<Worker> Workers;
        
        public void AddWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            throw new NotImplementedException();
        }

        public Worker GetWorker(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateWorker(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
