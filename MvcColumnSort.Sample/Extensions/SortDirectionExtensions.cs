using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MvcColumnSort.Sample.Extensions
{
    public static class SortDirectionExtension
    {
        /// <summary>
        /// Gets the sort direction from string. With the default being Ascending
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public static SortDirection GetSortDirectionFromString(this string direction)
        {
            SortDirection directionToSortBy = SortDirection.Ascending;
            SortDirection directionTest;

            if (Enum.TryParse<SortDirection>(direction, out directionTest))
            {
                directionToSortBy = directionTest;
            }

            return directionToSortBy;
        }
    }
}