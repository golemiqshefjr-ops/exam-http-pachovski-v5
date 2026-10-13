using System.Data.Entity;

namespace ExamMvc.Models
{
    public class ExamContext : DbContext
    {
        // "name=ExamContext" = името на connection string-а в Web.config
        public ExamContext() : base("name=ExamContext")
        {
            // Таблицата е създадена със скрипта CreateExamDb.sql —
            // Entity Framework не трябва да създава или променя базата.
            Database.SetInitializer<ExamContext>(null);
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
