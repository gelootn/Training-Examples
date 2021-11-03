using System.Collections.Generic;

namespace G3L.Examples.DDD.Application.Common.Models
{
    public class PagedOutputModel<TModel>
    {
        internal PagedOutputModel(
            IEnumerable<TModel> companies,
            int page,
            int totalPages
        )
        {
            Companies = companies;
            Page = page;
            TotalPages = totalPages;
        }
        
        public IEnumerable<TModel> Companies { get; }
        public int Page { get; }
        public int TotalPages { get; }
    }
}