using CourseWorkDB.Utilities;

namespace courseWork
{
    public class SortService
    {
        public static SortModel GetNewSort(SortModel oldSort, string field)
        {
            string order;

            if (oldSort.Field == field)
            {
                order = oldSort.Order == "ASC" ? "DESC" : "ASC";
            }
            else
            {
                order = "ASC";
            }
            var newSort = new SortModel(field, order);
            return newSort;
        }
    }
}
