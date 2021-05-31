using System;
using Workers.DataAccess.Entity;
using Workers.Model;

namespace Workers.Extentions
{
    public static class WorkerExtension
    {
        public static WorkerModel ToWorkerModel(this Worker workerEntity)
        {
            return new WorkerModel
            {
                Id = workerEntity.Id,
                Name = workerEntity.Name,
                LastName = workerEntity.LastName,
                BirthDate = workerEntity.BirthDate,
                Salary = workerEntity.Salary,
                StartWorkingAt = workerEntity.StartWorkingAt,
            };
        }

        public static Worker ToWorkerEntity(this WorkerModel workerEntity)
        {
            return new Worker
            {
                Id = workerEntity.Id,
                Name = workerEntity.Name,
                LastName = workerEntity.LastName,
                BirthDate = workerEntity.BirthDate ?? new DateTime(1, 1, 1),
                Salary = workerEntity.Salary,
                StartWorkingAt = workerEntity.StartWorkingAt ?? DateTime.Today,
            };
        }
    }
}
