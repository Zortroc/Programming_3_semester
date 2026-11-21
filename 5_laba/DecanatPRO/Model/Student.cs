using System.ComponentModel;

namespace Model
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name 
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }     
        }
        private string _name;
        public string Speciality
        {
            get { return _speciality; }
            set { _speciality = value; OnPropertyChanged(nameof(Speciality)); }
        }
        private string _speciality;
        public string Group
        {
            get { return _group; }
            set { _group = value; OnPropertyChanged(nameof(Group)); }
        }
        private string _group;

        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
