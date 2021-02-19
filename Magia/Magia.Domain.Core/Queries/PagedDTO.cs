using System.Collections.Generic;

namespace Magia.Domain.Core.Queries
{
    public class PagedDTO<TResult>
    {
        public PagedDTO(IEnumerable<TResult> list, long count)
        {
            List = list;
            Count = count;
        }

        public IEnumerable<TResult> List { get; set; }
        public long Count { get; set; }
    }
}
