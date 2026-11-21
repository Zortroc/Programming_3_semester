using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand AddStudentCommand { get; set; }
        public RelayCommand DeleteStudentCommand { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        private Logic _logic;

        public string NewStudentName
        {
            get { return _newStudentName; }
            set { _newStudentName = value; OnPropertyChanged(nameof(NewStudentName)); }
        }
        private string _newStudentName;

        public StudentViewModel()
        {
            AddStudentCommand = new RelayCommand(AddNewStudent);
            DeleteStudentCommand = new RelayCommand(DeleteSelectedStudent);
            _logic = new Logic();
            Students = new ObservableCollection<Student>();

            foreach (string[] student in _logic.ShowTableList())
            {
                Students.Add(new Student
                {
                    Name = student[0],
                    Speciality = student[1],
                    Group = student[2],
                }
                );
            }
        }

        public string NewStudentSpeciality
        {
            get { return _newStudentSpeciality; }
            set { _newStudentSpeciality = value; OnPropertyChanged(nameof(NewStudentSpeciality)); }
        }
        private string _newStudentSpeciality;

        public string NewStudentGroup
        {
            get { return _newStudentGroup; }
            set {  _newStudentGroup = value; OnPropertyChanged(nameof(NewStudentGroup)); }
        }
        private string _newStudentGroup;

        private Student _currentStudent;

        public Student CurrentStudent 
        {
            get { return _currentStudent; }
            set { _currentStudent = value; OnPropertyChanged(nameof(CurrentStudent)); }
        }

        private void DeleteSelectedStudent()
        {
            if (CurrentStudent == null)
            {
                ErrorMessage = "Ошибка: выберите студента для удаления.";
                return;
            }

            int studentNumber = Students.IndexOf(CurrentStudent) + 1;

            _logic.DeleteStudent(studentNumber);

            Students.Remove(CurrentStudent);
            CurrentStudent = null;

            ErrorMessage = "";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddNewStudent()
        {
            try
            {
                _logic.AddStudent(
                    NewStudentName,
                    NewStudentSpeciality,
                    NewStudentGroup
                );

                List<string[]> students = _logic.ShowTableList();
                string[] student = students[students.Count - 1];

                Students.Add(new Student
                {
                    Name = student[0],
                    Speciality = student[1],
                    Group = student[2]
                });

                ErrorMessage = "";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
