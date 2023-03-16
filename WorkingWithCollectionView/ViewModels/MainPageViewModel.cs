using BindingToObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithCollectionView.ViewModels
{
    internal class MainPageViewModels:INotifyPropertyChanged
    {
        public Command LoadStudentsCommand { get; private set; }
    
        private Student _student;

        public event PropertyChangedEventHandler PropertyChanged;

        #region בכל שינוי בשדות נפעיל את האירוע
        public Student Student { get => _student; set { if (_student != value) { _student = value; OnPropertyChanged("Student"); } } }

        private void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
        public ObservableCollection<Student> Students { get; set; }
        public MainPageViewModels()
        {
            //נגדיר רשימה ריקה
            Students = new ObservableCollection<Student>();
            //נאתחל את התלמיד הבודד לריק
            Student = new() { Image = "dotnet_bot.svg", Name = "ברירת מחדל", BirthDate = new DateTime() };
            LoadStudentsCommand = new Command(LoadStudents);
        }
        //נקשר את הדף שלנו לאובייקט המכיל את הקוד שלו
       
        private void LoadStudents()
        {
            this.Students.Clear();
            //דוגמה להוספת תלמיד בעקבות השינוי של גרסא 6 - אין צורך לציין אחרי
            //new שם מחלקה
            Students.Add(new() { Name = "Roni", Image = "roni.jpg", BirthDate = new DateTime(2006, 2, 19) });
            //הוספת תלמיד בדרך המלאה
            Students.Add(new Student { Name = "Omer", BirthDate = new DateTime(2006, 2, 9), Image = "omer.jpg" });
            Students.Add(new() { Name = "Maya", Image = "maya.jpg", BirthDate = new DateTime(2006, 10, 13) });

            Student = Students[0];

        }
    }
}
#endregion