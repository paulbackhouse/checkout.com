using System.Linq;

namespace Checkout.Extensions
{
    /// <summary>
    /// Query extensions for paging Iqueryabes results
    /// </summary>
    public static class QueryExtensions
    {

        /// <summary>
        /// page a query
        /// </summary>
        public static IQueryable<T> Paged<T>(this IQueryable<T> query, PagerDto pager) 
            where T : class
        {
            pager.Total = query.Count();

            int skip = pager.PageIndex * pager.PageSize;

            return query.Skip(skip)
                        .Take(pager.PageSize);
        }

    }
}
