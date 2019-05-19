using System.Windows;

namespace Students_DB_Application
{
    public partial class StudentsInteractionWindow : Window
    {
        public Student Student { get; private set; }

        public StudentsInteractionWindow(Student p)
        {
            InitializeComponent();
            // Контекст данных окна
            Student = p;
            this.DataContext = Student;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}