using SoftLine.Trebol.Application.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SoftLine.Trebol.Infrastructure.Specification;

public class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            inputQuery = inputQuery.Where(spec.Criteria);
        }

        if (spec.Orderby != null)
        {
            inputQuery = inputQuery.OrderBy(spec.Orderby);
        }

        if (spec.OrderbyDescending != null)
        {
            inputQuery = inputQuery.OrderByDescending(spec.OrderbyDescending);
        }

        if (spec.IsPagingenable)
        {
            inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
        }

        inputQuery = spec.Includes!.Aggregate(inputQuery, (current, include) => current.Include(include)).AsSplitQuery().AsNoTracking();

        return inputQuery;
    }
}
