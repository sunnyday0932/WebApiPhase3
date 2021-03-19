using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApiPhase3Common.Model;

namespace WebApiPhase3Common.Helper
{
    public static class PagingHelper
    {
        /// <summary>
        /// Orders the specified paging.
        /// </summary>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="paging">The paging.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">paging</exception>
        public static IEnumerable<TData> Order<TData>(
            this IEnumerable<TData> result,
            ref PagingInfoModel paging)
        {
            if (paging is null)
            {
                throw new ArgumentNullException(nameof(paging));
            }

            paging.TotalCount = result.Count();
            var resultList = result.ToArray().Cast<TData>();

            var orederColumn = 
                paging.OrderColumName 
                ?? typeof(TData).GetProperties().Take(1).Select(x => x.Name).First();
            if (paging.PageIndex is 0 &&
                paging.PageSize is 0)
            {
                paging.PageIndex = 1;
                paging.PageSize = resultList.Count();
            }

            //Order
            var property = typeof(TData).GetProperty(
                orederColumn,
                BindingFlags.Instance|
                BindingFlags.IgnoreCase|
                BindingFlags.Public);

            if (property != null)
            {
                if (paging.Descending)
                {
                    resultList = resultList.OrderByDescending(column => property.GetValue(column, null));
                }
                else
                {
                    resultList = resultList.OrderBy(column => property.GetValue(column, null));
                }
            }

            resultList = resultList
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return resultList;
        }

        /// <summary>
        /// Orders the specified order.
        /// </summary>
        /// <typeparam name="TData">The type of the data.</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="order">The order.</param>
        /// <param name="paging">The paging.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">paging</exception>
        public static IEnumerable<TData> Order<TData>(
            this IEnumerable<TData> result,
            Func<TData,object> order,
            ref PagingInfoModel paging)
        {
            if (paging is null)
            {
                throw new ArgumentNullException(nameof(paging));
            }

            paging.TotalCount = result.Count();
            var resultList = result.ToArray().Cast<TData>();

            if (paging.PageIndex is 0 &&
                paging.PageSize is 0)
            {
                paging.PageSize = 1;
                paging.PageSize = resultList.Count();
            }

            //Order
            if (paging.Descending)
            {
                resultList = resultList.OrderByDescending(order);
            }
            else
            {
                resultList = resultList.OrderBy(order);
            }

            resultList = resultList
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return resultList;
        }
    }
}
