using System.Data.Entity;

namespace Students_DB_Application
{// Контекст данных для взаимодействия с БД
    public class DBContext : DbContext
    {
        public DBContext() : base("StudentsDBConnection")
        {
        }
        public DbSet<Student> Students{ get; set; }
    }
}