using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace MvcColumnSort
{
    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        /// Gets the route value dictionary from a NameValueCollection usually the query string.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection queryString)
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();

            if (queryString != null)
            {
                foreach (string key in queryString.AllKeys.Where(key => key != null))
                {
                    if (!routeValues.Keys.Contains(key))
                    {
                        routeValues[key] = queryString[key];
                    }
                }
            }

            return routeValues;
        }
    }
}
