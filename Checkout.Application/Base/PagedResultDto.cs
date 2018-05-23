using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    /// <summary>
    /// an object containing paged result data
    /// </summary>
    public class PagedResultDto<TResult> where TResult : class
    {

        public PagedResultDto(IEnumerable<TResult> items, int pageIndex, int pageSize, long total)
        {
            Items = items.ToList();
            Pager = new PagerDto { PageIndex = pageIndex, PageSize = pageSize, Total = total };
        }

        public PagedResultDto(IEnumerable<TResult> items, PagerDto pager)
        {
            Items = items.ToList();
            Pager = new PagerDto { PageIndex = pager.PageIndex, PageSize = pager.PageSize, Total = pager.Total };
        }

        public IReadOnlyList<TResult> Items { get; set; }

        public PagerDto Pager { get; set; }
    }
}
