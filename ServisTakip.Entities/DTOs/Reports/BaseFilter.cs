namespace ServisTakip.Entities.DTOs.Reports
{
    public class BaseFilter
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount => CurrentPage * PageSize;
        public int RowCount { get; set; }
        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);
    }
}
