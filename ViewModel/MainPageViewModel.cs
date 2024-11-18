using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using to_do.Model;

namespace to_do.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Tasks> Tasks { get; set; }
        public Tasks NewTask { get; set; }

        public ICommand AddTaskCmd { get; }

        public MainPageViewModel()
        {
            Tasks = new ObservableCollection<Tasks>
            {
                new Tasks { Id = 1, Task = "Task 1", Description = "Description 1", IsDone = false },
                new Tasks { Id = 2, Task = "Task 2", Description = "Description 2", IsDone = false },
                new Tasks { Id = 3, Task = "Task 3", Description = "Description 3", IsDone = false }
            };

            NewTask = new Tasks();

            AddTaskCmd = new Command(AddTask);
        }

        private void AddTask()
        {
            NewTask.Id = Tasks.Count + 1;
            Tasks.Add(new Tasks
            {
                Id = NewTask.Id,
                Task = NewTask.Task,
                Description = NewTask.Description,
                IsDone = NewTask.IsDone
            });

            NewTask = new Tasks();
            OnPropertyChanged(nameof(NewTask));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}