namespace CourseWorkDB
{
    public abstract class BaseRepository<T>
    {
        protected string connectionString = "Server=localhost\\SQLEXPRESS;Database=agency;TrustServerCertificate=true;Trusted_Connection=True;";
      
    }
}
