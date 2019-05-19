
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Students_DB_Application
{ 
    public class InteractionBDViewModel : INotifyPropertyChanged
    {
        DBContext db;
        DBCommand addCommand;
        DBCommand editCommand;
        DBCommand deleteCommand;
        IEnumerable<Student> students;

        public IEnumerable<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged("Students");
            }
        }
        // Загружаем данные из бд в локальный кэш
        public InteractionBDViewModel()
        {
            db = new DBContext();
            db.Students.Load();
            Students = db.Students.Local.ToBindingList();
        }
       
 
       // команда добавления
       public DBCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new DBCommand((o) =>
                  {
                       StudentsInteractionWindow studentsInteractionWindow = new StudentsInteractionWindow(new Student());
                      if (studentsInteractionWindow.ShowDialog() == true)
                      {
                          Student student = studentsInteractionWindow.Student;
                          db.Students.Add(student);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public DBCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new DBCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Student student = selectedItem as Student;

                      Student vm = new Student()
                      {
                          ID = student.ID,
                          ФИО = student.ФИО,
                          Специальность = student.Специальность,
                          Группа = student.Группа,
                          Средний_Балл = student.Средний_Балл,
                      };
                      StudentsInteractionWindow studentsInteractionWindow = new StudentsInteractionWindow(vm);
                      
                      if (studentsInteractionWindow.ShowDialog() == true)
                      {
                          // получаем измененный объект
                          student = db.Students.Find(studentsInteractionWindow.Student.ID);
                          if (student != null)
                          {
                              student.ID = studentsInteractionWindow.Student.ID;
                              student.ФИО = studentsInteractionWindow.Student.ФИО;
                              student.Специальность = studentsInteractionWindow.Student.Специальность;
                              student.Группа = studentsInteractionWindow.Student.Группа;
                              student.Средний_Балл = studentsInteractionWindow.Student.Средний_Балл;
                              db.Entry(student).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }
        // команда удаления
        public DBCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new DBCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Student student = selectedItem as Student;
                      db.Students.Remove(student);
                      db.SaveChanges();
                  }));
            }
        }
        //Объявление события, реагирующего на изменение данных
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}