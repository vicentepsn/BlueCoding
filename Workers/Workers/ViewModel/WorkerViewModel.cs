using System;
using System.Collections.Generic;
using System.Text;
using Workers.Model;
using Workers.Service;

namespace Workers.ViewModel
{
    public class WorkerViewModel
    {
        private readonly IWorkerService _workerService;

        public WorkerViewModel(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public WorkerModel activeWorker;

        public void AddWorker()
        {
            var worker = activeWorker.ToEntity();

            _workerService.AddWorker(worker);
        }


    }
}
