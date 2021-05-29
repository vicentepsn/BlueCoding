using System;
using System.Collections.Generic;
using System.Text;
using Workers.Entity;
using Workers.Repository;

namespace Workers.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _worderRepository;

        public WorkerService(IWorkerRepository worderRepository)
        {
            _worderRepository = worderRepository;
        }

        public IEnumerable<Worker> GetWorker()
        {
            return _worderRepository.GetAllWorkers();
        }

        public void AddWorker(Worker worker)
        {
            try
            {
                _worderRepository.AddWorker(worker);
            }
            catch(Exception ex)
            {
                // write some log
                // return information
            }
        }

        public void UpdateWorker(Worker worker)
        {
            try
            {
                var currentWorker = _worderRepository.GetWorker(worker.Id);

                currentWorker.Name = worker.Name;
                ///
                _worderRepository.UpdateWorker(currentWorker);
            }
            catch (Exception ex)
            {
                // write some log
                // return information
            }
        }
    }
}
