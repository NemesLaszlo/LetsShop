using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; } // Take 5 elements from the first page and set the skip to "none", than to get the 2.page's 5 elements, skip the first 5 -> we are on the 2.page.
        bool IsPagingEnabled { get; }

        // Using ThenInclude with the specification pattern
        List<string> IncludeStrings { get; }
    }
}
