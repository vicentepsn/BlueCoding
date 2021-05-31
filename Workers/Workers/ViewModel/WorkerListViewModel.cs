using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Workers.Extentions;
using Workers.Model;
using Workers.Service;
using Workers.View;

namespace Workers.ViewModel
{
    public class WorkerListViewModel : BaseNotifyPropertyChanged
    {
        public ObservableCollection<WorkerModel> Workers { get; private set; }

        private readonly IWorkerService _workerService;

        private WorkerModel _selectedWorker;
        public WorkerModel SelectedWorker
        {
            get { return _selectedWorker; }
            set { SetField(ref _selectedWorker, value); }
        }

        public WorkerListViewModel(IWorkerService workerService)
        {
            _workerService = workerService;

            var workerEntities = _workerService.GetAllWorkers();
            Workers = new ObservableCollection<WorkerModel>(workerEntities.Select(_ => _.ToWorkerModel()));
            
            _selectedWorker = Workers.FirstOrDefault();
        }

        #region Commands
        private RelayCommand _addCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;

        private void AddWorker()
        {
            var newWorker = new WorkerModel();

            var workerView = new WorkerView();
            workerView.DataContext = newWorker;
            workerView.ShowDialog();

            if (workerView.DialogResult.HasValue && workerView.DialogResult.Value)
            {
                var workerEntity = newWorker.ToWorkerEntity();
                _workerService.AddWorker(workerEntity);
                newWorker.Id = workerEntity.Id;
                Workers.Add(newWorker);
            }
        }

        private bool CanAddWorkder() => true;

        public ICommand AddCommand
        {
            get => _addCommand ?? new RelayCommand(param => AddWorker(), param => CanAddWorkder());
        }


        private void EditWorker()
        {
            var workerView = new WorkerView();
            var workerToEdit = _selectedWorker.Clone();
            workerView.DataContext = workerToEdit;
            workerView.ShowDialog();

            if (workerView.DialogResult.HasValue && workerView.DialogResult.Value)
            {
                var workerEntity = workerToEdit.ToWorkerEntity();
                _workerService.UpdateWorker(workerEntity);
                _selectedWorker.UpdateValues(workerToEdit);
            }
        }

        private bool CanEditWorkder()
            => _selectedWorker != null;

        public ICommand EditCommand
        {
            get => _editCommand ?? new RelayCommand(param => EditWorker(), param => CanEditWorkder());
        }


        private void DeleteWorker()
        {
            _workerService.DeleteWorker(_selectedWorker.Id);

            Workers.Remove(_selectedWorker);
            _selectedWorker = Workers.FirstOrDefault();
        }

        private bool CanDeleteWorkder()
            => _selectedWorker != null;

        public ICommand DeleteCommand
        {
            get => _deleteCommand ?? new RelayCommand(param => DeleteWorker(), param => CanDeleteWorkder());
        }

        #endregion
    }
}
