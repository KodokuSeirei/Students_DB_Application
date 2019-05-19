
using System.Windows;

namespace Students_DB_Application
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Контекст данных окна
            this.DataContext = new InteractionBDViewModel();
        }

       
    } }