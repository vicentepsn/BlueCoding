using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Workers.ViewModel;

namespace Workers.View
{
    /// <summary>
    /// Interaction logic for WorkerListView.xaml
    /// </summary>
    public partial class WorkerListView : Window
    {
        public WorkerListView(WorkerListViewModel workerListViewModel)
        {
            InitializeComponent();

            DataContext = workerListViewModel;
        }
    }
}
