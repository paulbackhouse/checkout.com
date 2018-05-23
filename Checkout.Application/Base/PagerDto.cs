namespace Checkout
{
    /// <summary>
    /// an object for containing paging related data
    /// </summary>
    public class PagerDto
    {
        public PagerDto() { }

        public PagerDto(int pageIndex)
        {
            this.PageIndex = pageIndex;
        }

        public PagerDto(int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }

        public long Total { get; set; }

        public int PageNumber
        {
            get { return PageIndex + 1; }
        }

        public int PageCount
        {
            get
            {
                return Total > 0
                            ? (int)System.Math.Ceiling(Total / (double)PageSize)
                            : 0;

            }
        }

        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; } = Constants.DefaultPageSize;
      
        public bool IsLastPage
        {
            get
            {

                if (PageSize >= Total)
                    return true;

                return (PageNumber == PageCount);
            }
        }

        public bool IsFirstPage
        {
            get
            {
                return PageIndex < 1;
            }
        }

    }
}
