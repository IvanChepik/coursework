namespace CourseWorkDB.Utilities
{
    public class SortModel
    {
        public string Field { get; set; }
        public string Order { get; set; }
        public SortModel(string field, string order) 
        {
            Field = field;
            Order = order;
        }  
    }
}
