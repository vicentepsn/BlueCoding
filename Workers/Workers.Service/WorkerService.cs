using System;
using System.Collections.Generic;
using Workers.DataAccess.Entity;
using Workers.DataAccess.Repository;

namespace Workers.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _worderRepository;

        public WorkerService(IWorkerRepository worderRepository)
        {
            _worderRepository = worderRepository;
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _worderRepository.GetAllWorkers();
        }

        public Worker GetWorkerById(int id)
        {
            return _worderRepository.GetWorker(id);
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
                _worderRepository.UpdateWorker(worker);
            }
            catch (Exception ex)
            {
                // write some log
                // return information
            }
        }

        public void DeleteWorker(int id)
        {
            try
            {
                _worderRepository.DeleteWorker(id);
            }
            catch (Exception ex)
            {
                // write some log
                // return information
            }
        }
    }
}
