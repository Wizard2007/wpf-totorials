using FirstApp.Commands;
using FirstApp.Model;
using System.Collections.ObjectModel;

namespace FirstApp.ViewModel
{
    public class StudentViewModel
    {
        private Student _selectedStudent;

        public StudentViewModel()
        {
            LoadStudents();
            DeleteCommand = new MyCommand(OnDelete, CanDelete);
        }

        public MyCommand DeleteCommand { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public void LoadStudents() =>
            Students = new ObservableCollection<Student>
            {
                new Student { FirstName = "Mark", LastName = "Allain" },
                new Student { FirstName = "Allen", LastName = "Brown" },
                new Student { FirstName = "Linda", LastName = "Hamerski" }
            };        

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanDelete() => SelectedStudent != null;

        private void OnDelete() => Students.Remove(SelectedStudent);
    }
}
