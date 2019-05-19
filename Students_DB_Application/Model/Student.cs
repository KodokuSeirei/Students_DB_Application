using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Students_DB_Application
{
    public class Student : INotifyPropertyChanged
    {
        //Переменные, что после получения данных из БД будут возвращены свойствам
        int iD;
        private string фИО;
        private string специальность;
        private string группа;      
        private double средний_Балл;
        //Свойства 
        public int ID
        {
            get { return iD; }
            set
            {
                iD= value;
                OnPropertyChanged("ID");
            }
        }

        public string ФИО
        {
            get { return фИО; }
            set
            {
                фИО = value;
                OnPropertyChanged("ФИО");
            }
        }
        public string Специальность
        {
            get { return специальность; }
            set
            {
                специальность = value;
                OnPropertyChanged("Специальность");
            }
        }
        public string Группа
        {
            get { return группа; }
            set
            {
                группа = value;
                OnPropertyChanged("Группа");
            }

        }
        public double Средний_Балл
        {
            get { return средний_Балл; }
            set
            {

                средний_Балл = value;
                OnPropertyChanged("Средний_Балл");
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