namespace Tennis.Domain.Common;

public static class EnumerableExtensions
{
     public static decimal AverageOrZero<T>(this IEnumerable<T> source, Func<T, decimal> selector)
     {
          var enumerable = source.ToList();
          return enumerable.Any() ? enumerable.Average(selector) : 0;
     }
}