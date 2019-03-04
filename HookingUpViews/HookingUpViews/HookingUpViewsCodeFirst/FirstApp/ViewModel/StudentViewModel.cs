using FirstApp.Model;
using System.Collections.ObjectModel;

namespace FirstApp.ViewModel
{
    public class StudentViewModel
    {
        public StudentViewModel() => LoadStudents();
        public ObservableCollection<Student> Students { get; set; }

        public void LoadStudents() =>
            Students = new ObservableCollection<Student>
            {
                new Student { FirstName = "Mark", LastName = "Allain" },
                new Student { FirstName = "Allen", LastName = "Brown" },
                new Student { FirstName = "Linda", LastName = "Hamerski" }
            };
    }
}
